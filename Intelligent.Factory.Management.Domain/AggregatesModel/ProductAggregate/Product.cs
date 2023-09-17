using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity, IAggregateRoot
{
    public Product(string description)
    {
        _productItems = new List<ProductItem>();
        Description = description;
    }

    private string Description { get; set; }

    private readonly List<ProductItem> _productItems;

    public IReadOnlyCollection<ProductItem> ProductItems => _productItems;

    /// <summary>
    /// 新增item
    /// </summary>
    /// <param name="productType"></param>
    /// <param name="name"></param>
    /// <param name="specifications"></param>
    /// <param name="amount"></param>
    /// <param name="unit"></param>
    /// <param name="material"></param>
    /// <param name="technicalRequirements"></param>
    /// <param name="remark"></param>
    public void AddProductItem(ProductType productType, string name, string specifications, int amount, string unit,
        string material, string technicalRequirements, string remark)
    {
        _productItems.Add(new ProductItem(productType, name, specifications, amount, unit, material,
            technicalRequirements, remark));
    }
}