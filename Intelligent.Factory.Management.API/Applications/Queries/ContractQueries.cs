using AutoMapper;
using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ContractQueries : IContractQueries
{
    private readonly IContractRepository _contractRepository;

    private readonly IMapper _mapper;


    public ContractQueries(IContractRepository contractRepository, IMapper mapper)
    {
        _contractRepository = contractRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContractListDto>> GetContractListAsync(int pageIndex, int pageSize)
    {
        var contracts = await _contractRepository.GetListWithPageAsync(pageIndex, pageSize);

        return contracts.Select(t => _mapper.Map<ContractListDto>(t));
    }

    public async Task<int> GetAccountAsync()
    {
        return await _contractRepository.GetAccount();
    }

    public IAsyncEnumerable<ContractDetailDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

}