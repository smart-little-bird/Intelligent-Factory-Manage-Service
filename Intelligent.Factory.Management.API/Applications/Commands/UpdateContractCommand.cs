using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class UpdateContractCommand : IRequest<int>
{
    public UpdateContractCommand()
    {
    }

    public UpdateContractCommand(int id, IEnumerable<UpdateContractItemDto> updateContractItemDtos) : this()
    {
        Id = id;
        UpdateContractItemDtos = updateContractItemDtos;
    }

    [FromRoute] public int Id { get; set; }

    public IEnumerable<UpdateContractItemDto> UpdateContractItemDtos { get; set; }

    public record UpdateContractItemDto
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


public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, int>
{
    private readonly IContractRepository _contractRepository;

    public UpdateContractCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<int> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetAsync(request.Id);

        if (contract is null) throw new Exception($"不存在id为 {request.Id} 的合同");

        contract.RemoveContractContexts();

        foreach (var itemDto in request.UpdateContractItemDtos)
        {
            contract.AddContractContext(itemDto.ProductName, itemDto.Material, itemDto.Unit, itemDto.UnitPrice,
                itemDto.Amount, itemDto.IsIndependent, itemDto.ProductId);
        }

        await _contractRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);

        return contract.Id;
    }
}