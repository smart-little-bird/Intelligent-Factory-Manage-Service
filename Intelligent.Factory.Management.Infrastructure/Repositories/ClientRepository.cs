using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Intelligent.Factory.Management.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IntelligentFactoryManagementContext _context;

    public ClientRepository(IntelligentFactoryManagementContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Client Add(Client client)
    {
        return _context.Clients.Add(client).Entity;
    }

    public Client Update(Client client)
    {
        return _context.Clients.Update(client).Entity;
    }

    public async Task DeleteAsync(int id)
    {
        _context.Clients.Remove(
            (await _context.Clients.SingleOrDefaultAsync(t => t.Id == id))!
        );
    }

    public async Task<Client?> FindByIdAsync(int id)
    {
        var client = await _context.Clients.Include(b => b.ClientAgent)
            .Include(b => b.Address)
            .Include(b => b.Bank)
            .Where(b => b.Id == id)
            .SingleOrDefaultAsync();
        return client;
    }
}