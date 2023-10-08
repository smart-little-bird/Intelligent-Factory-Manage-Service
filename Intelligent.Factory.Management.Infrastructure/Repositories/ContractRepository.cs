using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Intelligent.Factory.Management.Infrastructure.Repositories;

public class ContractRepository : IContractRepository
{
    private readonly IntelligentFactoryManagementContext _context;

    public ContractRepository(IntelligentFactoryManagementContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Contract> GetAsync(int id)
    {
        return (await _context.Contracts.Include(t => t.ContractContexts)
            .Include(t => t.LogisticsInfo)
            .Include(t => t.PaymentMethod)
            .Include(t => t.FaxInfo)
            .FirstOrDefaultAsync(p => p.Id == id))!;
    }

    public Contract Add(Contract contract)
    {
        return _context.Contracts.Add(contract).Entity;
    }

    public Contract Update(Contract contract)
    {
        return _context.Contracts.Update(contract).Entity;
    }

    public Task<List<Contract>> GetListWithPageAsync(int pageIndex, int pageSize)
    {
        return _context.Contracts.Include(t => t.LogisticsInfo).Include(t => t.ContractContexts).OrderBy(p => p.Id)
            .Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
    }

    public Task<int> GetAccount()
    {
        return _context.Contracts.CountAsync();
    }
}