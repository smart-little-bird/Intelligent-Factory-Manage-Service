namespace Intelligent.Factory.Management.API.DTOs;


public class ContractListPageDto
{
    public IEnumerable<ContractListDto> ContractListDtos { get; set; }

    public PageDto Page { get; set; }

}

public class ContractListDto
{
    public int Id { get; set; }

    public string ContractNo { get; set; }

    public string ClientName { get; set; }

    public DateTime ShipDateTime { get; set; }

    public string ShipType { get; set; }

    public int TotalPrice { get; set; }
}