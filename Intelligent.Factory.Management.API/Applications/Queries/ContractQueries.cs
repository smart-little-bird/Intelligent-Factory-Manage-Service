using AutoMapper;
using Dapper;
using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Microsoft.Data.SqlClient;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ContractQueries:IContractQueries
{
    private readonly IContractRepository _contractRepository;

    private readonly IMapper _mapper;

    // private readonly IConfiguration _configuration;

    public ContractQueries(IContractRepository contractRepository, IMapper mapper, IConfiguration configuration)
    {
        _contractRepository = contractRepository;
        _mapper = mapper;
        // _configuration = configuration;
    }

    public async Task<IEnumerable<ContractListDto>> GetContractListAsync(int pageIndex, int pageSize)
    {
        var contracts =await _contractRepository.GetListWithPageAsync(pageIndex, pageSize);
        
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

    // public async IAsyncEnumerable<ContractDetailDto> GetAsync(int id)
    // {
    //     var connectionString = _configuration.GetConnectionString("db");
    //     await using var connection = new SqlConnection(connectionString);
    //     connection.Open();
    //     
    //     var result = await connection.QueryAsync<dynamic>(
    //         sql:$"SELECT * FROM IntelligentFactoryManagement.contract");
    //     
    //     var enumerable = result.ToList();
    //     
    //     if (enumerable.AsList().Count == 0)
    //         throw new KeyNotFoundException();
    //     
    //     foreach (var item in enumerable)
    //     {
    //         yield return MapContractDetailDto(item);
    //     }
    // }
    //
    private static ContractDetailDto MapContractDetailDto(dynamic result)
    {
        return new ContractDetailDto
        {
            
        };
    }
}