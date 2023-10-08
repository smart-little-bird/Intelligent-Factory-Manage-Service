using System.Runtime.Serialization;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

namespace Intelligent.Factory.Management.API.DTOs;

[DataContract]
public class ContractDetailDto
{
    public ContractDetailDto()
    {
    }

    public ContractDetailDto(int id, string contractNo, string phone, string clientName, DateTime shipDateTime,
        string shipType, int totalPrice, PaymentType paymentType, IEnumerable<int> percets,
        IEnumerable<ContractContextDetailDto> contractContextDetailDtos) : this()
    {
        Id = id;
        ContractNo = contractNo;
        Phone = phone;
        ClientName = clientName;
        ShipDateTime = shipDateTime;
        ShipType = shipType;
        TotalPrice = totalPrice;
        PaymentType = paymentType;
        Percets = percets;
        ContractContextDetailDtos = contractContextDetailDtos;
    }

    public int Id { get; set; }

    public string ContractNo { get; set; }

    public string Phone { get; set; }

    public string ClientName { get; set; }

    public DateTime ShipDateTime { get; set; }

    public string ShipType { get; set; }

    public int TotalPrice { get; set; }

    public PaymentType PaymentType { get; set; }

    public IEnumerable<int> Percets { get; set; }

    public IEnumerable<ContractContextDetailDto> ContractContextDetailDtos { get; set; }

    public FaxContextDto FaxContext { get; set; }
}

public record FaxContextDto
{
    public bool IsCombineFax { get; init; }

    public string TaxRate { get; init; }
}

public class ContractContextDetailDto
{
    public ContractContextDetailDto()
    {

    }

    public ContractContextDetailDto(string productName, string material, string unit, int unitPrice, int amount, bool isIndependent, int productId) : this()
    {
        ProductName = productName;
        Material = material;
        Unit = unit;
        UnitPrice = unitPrice;
        Amount = amount;
        IsIndependent = isIndependent;
        ProductId = productId;
    }

    public string ProductName { get; set; }

    public string Material { get; set; }

    public string Unit { get; set; }

    public int UnitPrice { get; set; }

    public int Amount { get; set; }

    public bool IsIndependent { get; set; }

    public int ProductId { get; set; }

    public int TotalPrice => UnitPrice * Amount;
}