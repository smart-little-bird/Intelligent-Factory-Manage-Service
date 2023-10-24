using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

namespace Intelligent.Factory.Management.API.Applications.Profiles;

public class ProductListAutoMapperProfile : AutoMapper.Profile
{
    public ProductListAutoMapperProfile()
    {
        CreateMap<Product, ProductListDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
            .ForMember(d => d.EntryCriteria, o => o.MapFrom(s => s.EntryCriteria))
            .ForMember(d => d.ProductListItemDtos, o => o.MapFrom(s => s.ProductItems));

        CreateMap<ProductItem, ProductListItemDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.TechnicalRequirements, o => o.MapFrom(s => s.TechnicalRequirements))
            .ForMember(d => d.Material, o => o.MapFrom(s => s.Material))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType))
            .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount))
            .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit))
            .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.UnitPrice))
            .ForMember(d => d.Specifications, o => o.MapFrom(s => s.Specifications))
            .ForMember(d => d.Remark, o => o.MapFrom(s => s.Remark));
    }
}