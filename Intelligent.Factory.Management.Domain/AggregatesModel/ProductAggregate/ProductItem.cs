using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

public class ProductItem : Entity
{
    private ProductItem()
    {

    }

    public ProductItem(ProductType productType, string name, string specifications, int amount, int unitPrice, string unit,
        string material, string technicalRequirements, string remark) : this()
    {
        ProductType = productType;
        Name = name;
        Specifications = specifications;
        Amount = amount;
        Unit = unit;
        UnitPrice = unitPrice;
        Material = material;
        TechnicalRequirements = technicalRequirements;
        Remark = remark;
    }

    /// <summary>
    /// 产品类型Id
    /// </summary>
    public ProductType ProductType { get; private set; }

    /// <summary>
    /// 产品明细名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    public string Specifications { get; private set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int Amount { get; private set; }

    /// <summary>
    /// 单价
    /// </summary>
    public int UnitPrice { get; private set; }

    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; private set; }

    /// <summary>
    /// 材料型号
    /// </summary>
    public string Material { get; private set; }

    /// <summary>
    /// 技术要求
    /// </summary>
    public string TechnicalRequirements { get; private set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int ProductId { get; private set; }
}