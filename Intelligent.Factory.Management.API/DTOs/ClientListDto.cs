using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

namespace Intelligent.Factory.Management.API.DTOs;

public class ClientListPageDto
{
    public IAsyncEnumerable<ClientListDto> ClientListDtos { get; set; }

    public PageDto Page { get; set; }

    public record PageDto
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Total { get; set; }
    }
}

public class ClientListDto
{
    public int Id { get; set; }

    /// <summary>
    /// 客户类型 0企业  1个人  2其他
    /// </summary>
    public ClientType ClientType { get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 街道
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    public string Province { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// 委托代理人
    /// </summary>
    public ClientListAgentDto ClientAgent { get; set; }

    /// <summary>
    /// 税号
    /// </summary>
    public string TFN { get; set; }

    /// <summary>
    /// 银行抬头
    /// </summary>
    public string BankTitle { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    public string BankAccount { get; set; }

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

    public record ClientListAgentDto
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}