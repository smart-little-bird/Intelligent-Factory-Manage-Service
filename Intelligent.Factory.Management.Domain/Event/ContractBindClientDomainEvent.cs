using MediatR;

namespace Intelligent.Factory.Management.Domain.Event;

public class ContractBindClientDomainEvent : INotification
{
    public ContractBindClientDomainEvent(int clientId,
        string clientName, string phone,
        string bankAccount, string street, string city, string province)
    {
        ClientId = clientId;
        ClientName = clientName;
        Phone = phone;
        BankAccount = bankAccount;
        Street = street;
        City = city;
        Province = province;
    }

    /// <summary>
    /// 客户Id
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    public string ClientName { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    public string BankAccount { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string Street { get; }
    /// <summary>
    /// 地址
    /// </summary>
    public string City { get; }
    /// <summary>
    /// 地址
    /// </summary>
    public string Province { get; }
}