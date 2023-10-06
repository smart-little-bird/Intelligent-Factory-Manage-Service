namespace Intelligent.Factory.Management.API.DTOs;


public class ContractListPageDto
{
    public IEnumerable<ContractListDto> ContractListDtos { get; set; }

    public PageDto Page { get; set; }

    public record PageDto
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Total { get; set; }
    }
}
public class ContractListDto
{
    public int ContractId { get; set; }
    
    public string ContractNo { get; private set; }

    public string ClientName { get; set; }
    
    public DateTime ShipDateTime { get;private set; }

    public string ShipType { get;private set; }
    

    public int TotalPrice { get; set; }
}