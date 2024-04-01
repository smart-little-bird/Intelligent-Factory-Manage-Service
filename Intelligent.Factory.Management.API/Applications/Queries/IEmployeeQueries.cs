using Intelligent.Factory.Management.API.DTOs;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public interface IEmployeeQueries
{
    Task<IEnumerable<EmployeeListDto>> GetListAsync();
}