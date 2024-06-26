﻿using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;
using Intelligent.Factory.Management.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Intelligent.Factory.Management.Infrastructure;

public sealed class IntelligentFactoryManagementContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "intelligent_factory_management";

    public DbSet<Client> Clients { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Contract?> Contracts { get; set; }
    
    
    public DbSet<Employee> Employees { get; set; }

    private readonly IMediator? _mediator;

    private IDbContextTransaction? _currentTransaction;

    public IntelligentFactoryManagementContext(DbContextOptions<IntelligentFactoryManagementContext> options) : base(options)
    { }


    public IntelligentFactoryManagementContext(DbContextOptions<IntelligentFactoryManagementContext> options, IMediator? mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
    }

    public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;

    public bool HasActiveTransaction => _currentTransaction != null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientAgentEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductItemEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new ContractEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ContractContextEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _mediator.DispatchDomainEventsAsync(this);

        await SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync();

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction)
            throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    private void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}