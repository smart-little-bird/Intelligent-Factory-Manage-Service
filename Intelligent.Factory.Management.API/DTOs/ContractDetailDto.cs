namespace Intelligent.Factory.Management.API.DTOs;

public class ContractDetailDto
{
    public int ContractId { get; set; }
    
    public string ContractNo { get;  set; }
    
    public string Phone { get; set; }

    public string ClientName { get; set; }
    
    public DateTime ShipDateTime { get; set; }

    public string ShipType { get; set; }
    
    public int TotalPrice { get; set; }
}