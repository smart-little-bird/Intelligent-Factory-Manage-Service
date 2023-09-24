using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class PaymentMethod : ValueObject
{
    public int Id { get; set; }
    
    public PaymentType PaymentType { get; set; }

    public int PayPercent { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PaymentType;
        yield return PayPercent;
    }
}