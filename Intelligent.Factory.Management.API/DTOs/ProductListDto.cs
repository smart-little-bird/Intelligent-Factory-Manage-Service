using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

namespace Intelligent.Factory.Management.API.DTOs;

public class ProductPageDto
{
    public ProductPageDto()
    {
    }

    public ProductPageDto(IEnumerable<ProductListDto> productListDtos, Page page) : this()
    {
        ProductListDtos = productListDtos;
        Page = page;
    }

    public IEnumerable<ProductListDto> ProductListDtos { get; set; }

    public Page Page { get; set; }
}

public class ProductListDto
{
    public ProductListDto()
    {
    }

    public ProductListDto(int id, string description, string entryCriteria, IEnumerable<ProductListItemDto> productListItemDtos) : this()
    {
        Id = id;
        Description = description;
        EntryCriteria = entryCriteria;
        ProductListItemDtos = productListItemDtos;
    }

    public int Id { get; set; }

    public string Description { get; set; }

    public string EntryCriteria { get; set; }

    public IEnumerable<ProductListItemDto> ProductListItemDtos { get; set; }
}

public class ProductListItemDto
{
    public ProductListItemDto()
    {
    }

    public ProductListItemDto(int id, ProductType productType, string name, string specifications, string unit, string material, string technicalRequirements, string remark) : this()
    {
        Id = id;
        ProductType = productType;
        Name = name;
        Specifications = specifications;
        Unit = unit;
        Material = material;
        TechnicalRequirements = technicalRequirements;
        Remark = remark;
    }

    public int Id { get; set; }

    public ProductType ProductType { get; private set; }

    public string Name { get; private set; }

    public string Specifications { get; private set; }

    public int Amount { get; private set; }

    public int UnitPrice { get; private set; }

    public string Unit { get; private set; }

    public string Material { get; private set; }

    public string TechnicalRequirements { get; private set; }

    public string Remark { get; private set; }

    public int TotalPrice => UnitPrice * Amount;
}