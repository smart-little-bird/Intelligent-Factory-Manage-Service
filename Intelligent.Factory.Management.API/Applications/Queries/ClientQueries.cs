using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ClientQueries:IClientQueries
{
    private string _connectionString = string.Empty;

    public ClientQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }
    
    public Task<Client> GetClientAsync(int id)
    {
        
        throw new NotImplementedException();
    }
}
