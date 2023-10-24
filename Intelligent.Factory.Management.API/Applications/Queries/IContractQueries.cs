using Intelligent.Factory.Management.API.DTOs;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public interface IContractQueries
{
    Task<IEnumerable<ContractListDto>> GetContractListAsync(int pageIndex, int pageSize);

    Task<int> GetAccountAsync();

    Task<ContractDetailDto> GetAsync(int id);
}