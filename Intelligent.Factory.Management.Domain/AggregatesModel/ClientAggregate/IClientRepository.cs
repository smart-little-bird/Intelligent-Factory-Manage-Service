using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

public interface IClientRepository: IRepository<Client>
{
    Client Add(Client client);
    
    Client Update(Client client);

    Task DeleteAsync(int id);

    Task<Client> FindByIdAsync(string id);
}