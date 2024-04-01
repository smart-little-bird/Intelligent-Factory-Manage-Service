using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

public interface IEmployeeRepository : IRepository<Employee>
{
    Employee Add(Employee employee);

    Employee Update(Employee client);

    Task DeleteAsync(int id);

    Task<IEnumerable<Employee>> GetList ();
}