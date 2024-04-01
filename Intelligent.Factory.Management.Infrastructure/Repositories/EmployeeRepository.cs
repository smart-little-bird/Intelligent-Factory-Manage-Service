using Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Intelligent.Factory.Management.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    
    private readonly IntelligentFactoryManagementContext _context;

    public EmployeeRepository(IntelligentFactoryManagementContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;
    
    public Employee Add(Employee employee)
    {
        return _context.Employees.Add(employee).Entity;
    }

    public Employee Update(Employee employee)
    {
        return _context.Employees.Update(employee).Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.SingleAsync(t => t.Id == id);
        _context.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetList()
    {
        return await _context.Employees.Include(b => b.BasicInfo)
            .Include(b => b.WorkingInfo).ToListAsync();
    }
}