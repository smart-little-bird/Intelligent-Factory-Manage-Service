using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;

namespace Intelligent.Factory.Management.API.Applications.Profiles;

public class EmployeeAutoMapperProfile : AutoMapper.Profile
{
    public EmployeeAutoMapperProfile()
    {
        CreateMap<Employee, EmployeeListDto>()
            .ForMember(d => d.EmployeeId, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Age, o => o.MapFrom(s => s.BasicInfo.Age))
            .ForMember(d => d.IdCardNo, o => o.MapFrom(s => s.BasicInfo.IdCardNo))
            .ForMember(d => d.Gender, o => o.MapFrom(s => s.BasicInfo.Gender))
            .ForMember(d => d.Phone, o => o.MapFrom(s => s.BasicInfo.Phone))
            .ForMember(d => d.EmployeeType, o => o.MapFrom(
                s => s.WorkingInfo.EmployeeType))
            .ForMember(d => d.WorkingYear, o => o.MapFrom(s => s.WorkingInfo.WorkingYear));
    }
    
}