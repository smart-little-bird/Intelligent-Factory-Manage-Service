using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

namespace Intelligent.Factory.Management.API.Applications.Profiles;

public class ContractListAutoMapperProfile: AutoMapper.Profile
{
    public ContractListAutoMapperProfile()
    {
        CreateMap<Contract, ContractListDto>()
            .ForMember(d => d.ContractId, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.ContractNo, o => o.MapFrom(s => s.ContractNo))
            .ForMember(d => d.ClientName, o => o.MapFrom(s => s.ClientName))
            .ForMember(d => d.ShipType, o => o.MapFrom(s => s.LogisticsInfo.ShipType))
            .ForMember(d => d.ShipDateTime, o => o.MapFrom(s => s.LogisticsInfo.ShipDateTime))
            .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.ContractContexts.Sum(t=>t.UnitPrice*t.Amount)));
    }
}