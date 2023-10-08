using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class FaxInfo : ValueObject
{
    public FaxInfo(bool isCombineFax, int taxRate)
    {
        IsCombineFax = isCombineFax;
        TaxRate = taxRate;
    }

    public bool IsCombineFax { get; set; }

    public int TaxRate { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsCombineFax;
        yield return TaxRate;
    }
}