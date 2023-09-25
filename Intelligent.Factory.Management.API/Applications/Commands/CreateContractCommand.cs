using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateContractCommand : IRequest<int>
{
    public CreateContractCommand()
    {
    }

    public CreateContractCommand(int clientId, string clientName, string phone, string bankAccount, string street,
        string city, string province):this()
    {
        ClientId = clientId;
        ClientName = clientName;
        Phone = phone;
        BankAccount = bankAccount;
        Street = street;
        City = city;
        Province = province;
        ContractItemDtos = new List<ContractItemDto>();
    }

    public int ClientId { get; set; }

    public string ClientName { get; set; }

    public string Phone { get; set; }

    public string BankAccount { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public IEnumerable<ContractItemDto> ContractItemDtos { get; set; }

    public ContractPayMethodDto ContractPayMethod { get; set; }

    public record ContractPayMethodDto
    {
        public PaymentType PaymentType { get; init; }

        public List<int>? PayPercents { get; init; }
    }

    public record ContractItemDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get;  set; }

        /// <summary>
        /// 材质
        /// </summary>
        public string Material { get;  set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get;  set; }

        /// <summary>
        /// 单价
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 是否为独立的产品
        /// </summary>
        public bool IsIndependent { get; set; }

        /// <summary>
        /// 绑定产品Id
        /// </summary>
        public int ProductId { get; set; }
    }
}

public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, int>
{
    private readonly IContractRepository _contractRepository;

    public CreateContractCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        var contractNo = string.Format("{0:yyyy}{0:MM}{0:dd}{1}", DateTime.Now,
            Convert.ToInt16(DateTime.Now.ToString("mm")) % 5);

        var contract = new Contract(contractNo);
        contract.BingClient(request.ClientId, request.ClientName, request.Phone, request.BankAccount, request.Street,
            request.City, request.Province);
        foreach (var contractItemDto in request.ContractItemDtos)
        {
            var contractContext = new ContractContext(contractItemDto.ProductName, contractItemDto.Material,
                contractItemDto.Unit,
                contractItemDto.UnitPrice, contractItemDto.Amount);
            contractContext.InitContactContextProperty(contractItemDto.IsIndependent, contractItemDto.ProductId);
        }
        var result = _contractRepository.Add(contract);

        await _contractRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        return result.Id;
    }
}