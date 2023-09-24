using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class ContractContext : Entity
{
    private ContractContext()
    {
    }

    public ContractContext(string productName, string material,
        string unit, int unitPrice, int amount) : this()
    {
        ProductName = productName;
        Material = material;
        Unit = unit;
        UnitPrice = unitPrice;
        Amount = amount;
    }

    public void InitContactContextProperty(bool isIndependent, int productId)
    {
        ContractContextProperty = new ContractContextProperty(isIndependent, productId);
    }

    public string ProductName { get; private set; }

    /// <summary>
    /// 合同内容属性
    /// </summary>
    public ContractContextProperty ContractContextProperty { get; set; }

    /// <summary>
    /// 材质
    /// </summary>
    public string Material { get; private set; }

    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; private set; }

    /// <summary>
    /// 单价
    /// </summary>
    public int UnitPrice { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int Amount { get; set; }

    public int ContractId { get; set; }

}