using Intelligent.Factory.Management.Domain.Exceptions;
using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

public class Client : Entity, IAggregateRoot
{
    /// <summary>
    /// 客户类型
    /// </summary>
    public ClientType ClientType { get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 地址
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// 委托代理人
    /// </summary>
    public ClientAgent ClientAgent { get; set; }

    /// <summary>
    /// 税号
    /// </summary>
    public string TFN { get; set; }

    /// <summary>
    /// 银行信息
    /// </summary>
    public Bank Bank { get; set; }

    /// <summary>
    /// 开票电话
    /// </summary>
    public string BillingTelephone { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    public string ContactNumber { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 传真
    /// </summary>
    public string Fax { get; set; }
    
    private Client()
    {
    }
    
    public Client(ClientType clientType,string name) : this()
    {
        ClientType = clientType;
        Name = name;
    }

    public void InitEnterpriseClient(string name, string phoneNumber )
    {
        this.ClientAgent = new ClientAgent(name, phoneNumber);
    }
    
    public void InitPersonageClient()
    {
        if (string.IsNullOrEmpty(ContactNumber))
        {
            throw new IntelligentFactoryDomainException("当客户为个人客户，不可以缺失联系电话");
        }
        ClientAgent = new ClientAgent(Name, ContactNumber);
    }
    
    public void AddAddress(string street, string city, string province, string zipcode)
    {
        Address = new Address(street, city, province, zipcode);
    }

    public void AddBank(string bankTitle, string bankAccount)
    {
        Bank = new Bank(bankTitle, bankAccount);
    }

    public void AddContactInfo(string tFN, string billingTelephone, string contactNumber, string email, string fax)
    {
        TFN = tFN;
        BillingTelephone = billingTelephone;
        ContactNumber = contactNumber;
        Email = email;
        Fax = fax;
    }
    
}