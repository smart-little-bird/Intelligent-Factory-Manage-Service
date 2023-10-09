using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;


namespace Intelligent.Factory.Management.API.Applications.Profiles;

public class ContractDetailAutoMapperProfile : AutoMapper.Profile
{
    public ContractDetailAutoMapperProfile()
    {
        CreateMap<Contract, ContractDetailDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.ContractNo, o => o.MapFrom(s => s.ContractNo))
            .ForMember(d => d.ClientName, o => o.MapFrom(s => s.ClientName))
            .ForMember(d => d.ShipType, o => o.MapFrom(s => s.LogisticsInfo.ShipType))
            .ForMember(d => d.ShipDateTime, o => o.MapFrom(s => s.LogisticsInfo.ShipDateTime))
            .ForMember(d => d.TotalPrice,
                o => o.MapFrom(s => (s.FaxInfo.TaxRate + 1) * s.ContractContexts.Sum(t => t.UnitPrice * t.Amount)))
            .ForMember(d => d.PaymentType, o => o.MapFrom(s => s.PaymentMethod.PaymentType))
            .ForMember(d => d.Percents, o => o.MapFrom<IEnumerable<int>>(s => s.PaymentMethod.PayPercents!))
            .ForMember(d => d.ContractContextDetailDtos, o => o.MapFrom(s => s.ContractContexts));
    }
}