using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

public class Bank : ValueObject
{
    public Bank()
    {
    }

    public Bank(string bankTitle, string bankAccount):this()
    {
        BankTitle = bankTitle;
        BankAccount = bankAccount;
    }

    /// <summary>
    /// 银行抬头
    /// </summary>
    public string BankTitle { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    public string BankAccount { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return BankTitle;
        yield return BankAccount;
    }
}