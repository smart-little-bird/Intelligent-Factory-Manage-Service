using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

namespace Intelligent.Factory.Management.API.Applications.Profiles;

public class ContractContextAutoMapperProfile : AutoMapper.Profile
{
    public ContractContextAutoMapperProfile()
    {
        CreateMap<ContractContext, ContractContextDetailDto>()
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ProductName))
            .ForMember(d => d.Material, o => o.MapFrom(s => s.Material))
            .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit))
            .ForMember(d => d.IsIndependent, o => o.MapFrom(s => s.ContractContextProperty.IsIndependent))
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ContractContextProperty.ProductId));
    }
}