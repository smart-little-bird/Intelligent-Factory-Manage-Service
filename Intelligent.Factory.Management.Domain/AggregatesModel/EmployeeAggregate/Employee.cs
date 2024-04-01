using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

public class Employee : Entity, IAggregateRoot
{
    public string EmployeeName { get; set; }

    public BasicInfo BasicInfo { get; set; }

    public WorkingInfo WorkingInfo { get; set; }


    private Employee()
    {
    }

    public Employee(string employeeName):this()
    {
        this.EmployeeName = employeeName;
    }

    public void InitEmployeeBasicInfo(string gender,int age, string phone, string idCardNo)
    {
        this.BasicInfo = new BasicInfo(gender, age, phone, idCardNo);
    }

    public void InitEmployeeWorkingInfo(string employeeType, double workingYear)
    {
        WorkingInfo = new WorkingInfo(employeeType, workingYear);
    }

}