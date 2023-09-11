using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateClientCommand  : IRequest<int>
{
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
    public  string City { get;set; }
    
    /// <summary>
    /// 省份
    /// </summary>
    public  string Province { get; set;}
    
    /// <summary>
    /// 编码
    /// </summary>
    public  string ZipCode { get;set; }

    /// <summary>
    /// 委托代理人
    /// </summary>
    public ClientAgentDto ClientAgent { get; set; }

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

    public record ClientAgentDto
    {
        public string Name { get; set; }
    
        public string PhoneNumber { get; set; }
    }
}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly IClientRepository _clientRepository;

    public CreateClientCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client(request.ClientType,request.Name);
        client.AddContactInfo(request.TFN,request.BillingTelephone,request.ContactNumber,request.Email,request.Fax);
        client.AddAddress(request.Street,request.City,request.Province,request.ZipCode);
        client.AddBank(request.BankTitle,request.BankAccount);
        
        switch (client.ClientType)
        {
            case ClientType.Enterprise:
                client.InitEnterpriseClient(request.ClientAgent.Name,request.ClientAgent.PhoneNumber);
                break;
            case ClientType.Personage:
                client.InitPersonageClient();
                break;
            case ClientType.ThreeWay:
                break;
        }

        var result = _clientRepository.Add(client: client);
        await _clientRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        return result.Id;
    }
}