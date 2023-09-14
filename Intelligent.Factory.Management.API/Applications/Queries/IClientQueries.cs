using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public interface IClientQueries
{
    IAsyncEnumerable<ClientListDto> GetClientListAsync(int pageIndex, int pageSize);
}