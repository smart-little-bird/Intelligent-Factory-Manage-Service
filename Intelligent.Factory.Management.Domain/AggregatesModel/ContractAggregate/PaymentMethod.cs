
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class PaymentMethod : ValueObject
{
    private PaymentMethod()
    {
    }

    public PaymentMethod(PaymentType paymentType,string payPercentJson):this()
    {
        PaymentType = paymentType;
        PayPercentJson = payPercentJson;
    }

    public PaymentType PaymentType { get; set; }

    public string PayPercentJson { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PaymentType;
        yield return PayPercentJson;
    }
}