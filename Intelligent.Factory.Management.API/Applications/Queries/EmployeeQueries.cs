using AutoMapper;
using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class EmployeeQueries:IEmployeeQueries
{
    private readonly IEmployeeRepository _employeeRepository;

    private readonly IMapper _mapper;

    public EmployeeQueries( IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<EmployeeListDto>> GetListAsync()
    {
        var contracts = await _employeeRepository.GetList();
        return contracts.Select(t => _mapper.Map<EmployeeListDto>(t));
    }
}