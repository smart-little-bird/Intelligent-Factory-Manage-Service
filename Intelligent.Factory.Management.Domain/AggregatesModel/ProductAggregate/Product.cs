using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity, IAggregateRoot
{
    public Product(string description, string entryCriteria)
    {
        _productItems = new List<ProductItem>();
        Description = description;
        EntryCriteria = entryCriteria;
    }

    public string Description { get; set; }

    public string EntryCriteria { get; set; }

    private readonly List<ProductItem> _productItems;

    public IReadOnlyCollection<ProductItem> ProductItems => _productItems;

    public void UpdateProduct(string description, string entryCriteria)
    {
        Description = description;
        EntryCriteria = entryCriteria;
    }

    /// <summary>
    /// 
    /// </summary>
    public void RemoveProductItems()
    {
        _productItems.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productType"></param>
    /// <param name="name"></param>
    /// <param name="specifications"></param>
    /// <param name="amount"></param>
    /// <param name="unitPrice"></param>
    /// <param name="unit"></param>
    /// <param name="material"></param>
    /// <param name="technicalRequirements"></param>
    /// <param name="remark"></param>
    public void AddProductItem(ProductType productType, string name, string specifications, int amount, int unitPrice, string unit,
        string material, string technicalRequirements, string remark)
    {
        _productItems.Add(new ProductItem(productType, name, specifications, amount, unitPrice, unit, material,
            technicalRequirements, remark));
    }
}