using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

public class BasicInfo : ValueObject
{
    public string Gender { get; set; }
    
    public int Age { get; set; }

    public string Phone { get; set; }

    public string IdCardNo { get; set; }

    public BasicInfo()
    {
    }

    public BasicInfo(string gender,int age, string phone, string idCardNo):this()
    {
        Gender = gender;
        Age = age;
        Phone = phone;
        IdCardNo = idCardNo;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Gender;
        yield return Age;
        yield return Phone;
        yield return IdCardNo;
    }
}