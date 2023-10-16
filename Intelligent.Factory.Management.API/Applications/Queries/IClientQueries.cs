using Intelligent.Factory.Management.API.DTOs;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public interface IClientQueries
{
    IAsyncEnumerable<ClientListDto> GetClientListAsync(int pageIndex, int pageSize);

    Task<int> GetAccountAsync();

    IAsyncEnumerable<ClientListDto> GetClientListAsync();
}