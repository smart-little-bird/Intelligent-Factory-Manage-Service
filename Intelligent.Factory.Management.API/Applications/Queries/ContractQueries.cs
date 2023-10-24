using AutoMapper;
using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ContractQueries : IContractQueries
{
    private readonly IContractRepository _contractRepository;

    private readonly IProductQueries _productQueries;

    private readonly IMapper _mapper;

    public ContractQueries(IContractRepository contractRepository, IMapper mapper, IProductQueries productQueries)
    {
        _contractRepository = contractRepository;
        _mapper = mapper;
        _productQueries = productQueries;
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

    public async Task<ContractDetailDto> GetAsync(int id)
    {
        var contract = await _contractRepository.GetAsync(id);
        if (contract == null) throw new Exception($"不存在id为{id}的合同");
        var contractDetailDto = _mapper.Map<ContractDetailDto>(contract);
        if (contractDetailDto.ContractContextDetailDtos.All(T => T.IsIndependent)) return contractDetailDto;
        {
            var contractContextDetailDto = contractDetailDto.ContractContextDetailDtos.First(T => T.IsIndependent);
            var productDetailDto = await _productQueries.GetAsync(contractContextDetailDto.ProductId);
            contractDetailDto.TechnologyStandard = productDetailDto.EntryCriteria;
        }
        return contractDetailDto;
    }

}