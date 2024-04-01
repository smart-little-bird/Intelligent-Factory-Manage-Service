using Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateEmployeeCommand : IRequest<int>
{
    public CreateEmployeeCommand()
    {

    }

    public CreateEmployeeCommand(string gender, string employeeName, string employeeType, int age, string phone, string idCardNo, double workingYear) : this()
    {
        EmployeeName = employeeName;
        EmployeeType = employeeType;
        Age = age;
        Phone = phone;
        IdCardNo = idCardNo;
        Gender = gender;
        WorkingYear = workingYear;
    }

    public string Gender { get; set; }

    public string EmployeeName { get; set; }

    public string EmployeeType { get; set; }

    public int Age { get; set; }

    public string Phone { get; set; }

    public string IdCardNo { get; set; }

    public double WorkingYear { get; set; }

}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee(request.EmployeeName);
        employee.InitEmployeeBasicInfo(request.Gender, request.Age, request.Phone, request.IdCardNo);
        employee.InitEmployeeWorkingInfo(request.EmployeeType, request.WorkingYear);
        var result = _employeeRepository.Add(employee);
        await _employeeRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        return result.Id;
    }
}
