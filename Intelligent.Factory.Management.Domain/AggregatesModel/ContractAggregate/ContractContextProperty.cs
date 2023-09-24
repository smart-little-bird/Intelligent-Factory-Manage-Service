using Intelligent.Factory.Management.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class ContractContextProperty : ValueObject
{
    
    private ContractContextProperty()
    {
    }

    public ContractContextProperty(bool isIndependent, int productId) : this()
    {
        IsIndependent = isIndependent;
        ProductId = productId;
    }

    public int Id { get; set; }

    /// <summary>
    /// 是否为独立的产品
    /// </summary>
    public bool IsIndependent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int ProductId { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsIndependent;
        yield return ProductId;
    }
}