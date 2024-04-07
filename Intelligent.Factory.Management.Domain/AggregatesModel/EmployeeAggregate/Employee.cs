using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

public class Employee : Entity, IAggregateRoot
{
    public string EmployeeName { get; set; }

    public DateTime EntryTime { get; set; }
    
    public BasicInfo BasicInfo { get; set; }

    public WorkingInfo WorkingInfo { get; set; }


    private Employee()
    {
    }

    public Employee(string employeeName,DateTime entryTime):this()
    {
        this.EmployeeName = employeeName;
        EntryTime = entryTime;
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