using System.Text.Json;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Intelligent.Factory.Management.Domain.Event;
using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class Contract : Entity, IAggregateRoot
{
    public Contract(string contractNo)
    {
        ContractNo = contractNo;
        _contractContexts = new List<ContractContext>();
    }

    /// <summary>
    /// 合同编号
    /// </summary>
    public string ContractNo { get; private set; }

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
    /// 合同明细
    /// </summary>
    private readonly List<ContractContext> _contractContexts;


    public IReadOnlyCollection<ContractContext> ContractContexts => _contractContexts;

    /// <summary>
    /// 支付方式
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public LogisticsInfo LogisticsInfo { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="clientName"></param>
    /// <param name="phone"></param>
    /// <param name="bankAccount"></param>
    /// <param name="street"></param>
    /// <param name="city"></param>
    /// <param name="province"></param>


    public void BingClient(int clientId,
        string clientName, string phone,
        string bankAccount, string street, string city, string province)
    {
        ClientId = clientId;
        ClientName = clientName;
        Phone = phone;
        AddDomainEvent(new ContractBindClientDomainEvent(clientId, clientName, phone, bankAccount, street, city, province));
    }

    public void AddContractContext(string productName, string material, string unit,
        int unitPrice, int amount, bool isIndependent, int productId)
    {
        var contractContext = new ContractContext(productName, material, unit, unitPrice, amount);
        contractContext.InitContactContextProperty(isIndependent, productId);
        _contractContexts.Add(contractContext);
    }

    public void InitLogisticsInfo(DateTime shipDateTime, string shipType, string logisticsUndertaker)
    {
        this.LogisticsInfo = new LogisticsInfo(shipDateTime, shipType, logisticsUndertaker);
    }

    public void DeterminePaymentMethod(PaymentType paymentType, List<int>? payPercent)
    {
        PaymentMethod = new PaymentMethod(paymentType, JsonSerializer.Serialize(payPercent));
    }
}