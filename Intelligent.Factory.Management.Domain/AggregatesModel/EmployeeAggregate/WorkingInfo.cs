using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

public class WorkingInfo: ValueObject
{
    public WorkingInfo()
    {
    }
    
    public WorkingInfo(string employeeType, double workingYear):this()
    {
        EmployeeType = employeeType;
        WorkingYear = workingYear;
    }

    public string EmployeeType { get; set; }
    
    public double WorkingYear { get; set; }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return EmployeeType;
        yield return WorkingYear;
    }
}