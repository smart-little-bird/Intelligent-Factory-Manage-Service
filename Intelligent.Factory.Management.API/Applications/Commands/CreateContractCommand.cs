using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateContractCommand : IRequest<int>
{
    public CreateContractCommand(bool isCombineFax)
    {
        IsCombineFax = isCombineFax;
    }

    public CreateContractCommand(int clientId, bool isCombineFax) : this(isCombineFax)
    {
        ClientId = clientId;
        IsCombineFax = isCombineFax;
        ContractItems = new List<ContractItemDto>();
    }

    public int ClientId { get; set; }

    public bool IsCombineFax { get; set; }

    public IEnumerable<ContractItemDto> ContractItems { get; set; }

    public ContractPayMethodDto ContractPayMethod { get; set; }

    public ContractShippingInfoDto ContractShippingInfo { get; set; }


    public record ContractShippingInfoDto
    {
        public DateTime ShipDateTime { get; init; }

        public string ShipType { get; init; }

        public string LogisticsUndertaker { get; init; }
    }

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
        public string ProductName { get; set; }

        /// <summary>
        /// 材质
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

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

    private readonly IClientRepository _clientRepository;

    public CreateContractCommandHandler(IContractRepository contractRepository, IClientRepository clientRepository)
    {
        _contractRepository = contractRepository;
        _clientRepository = clientRepository;
    }

    public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        var contractNo = string.Format("{0:yyyy}{0:MM}{0:dd}{1}", DateTime.Now,
            Convert.ToInt16(DateTime.Now.ToString("mm")) % 5);

        var contract = new Contract(contractNo);
        var client = await _clientRepository.FindByIdAsync(request.ClientId);
        contract.BingClient(request.ClientId, client!.Name, client.ContactNumber, client.Bank.BankAccount,
            client.Address.Street,
            client.Address.City, client.Address.Province);

        contract.DeterminePaymentMethod(request.ContractPayMethod.PaymentType, request.ContractPayMethod.PayPercents);
        contract.InitLogisticsInfo(request.ContractShippingInfo.ShipDateTime, request.ContractShippingInfo.ShipType,
            request.ContractShippingInfo.LogisticsUndertaker);
        contract.AddFaxContext(request.IsCombineFax);
        foreach (var itemDto in request.ContractItems)
        {
            contract.AddContractContext(itemDto.ProductName, itemDto.Material, itemDto.Unit, itemDto.UnitPrice,
                itemDto.Amount, itemDto.IsIndependent, itemDto.ProductId);
        }

        var result = _contractRepository.Add(contract);
        await _contractRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);

        // todo add the  service to generator the pdf

        return result!.Id;
    }
}