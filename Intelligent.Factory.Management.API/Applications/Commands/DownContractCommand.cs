using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class DownContractCommand: IRequest<int>
{
    public DownContractCommand()
    {
    }

    public DownContractCommand(int id):this()
    {
        Id = id;
    }

    public int Id { get; set; }
}

public class DownContractCommandHandler : 
    IRequestHandler<DownContractCommand, int>
{
    private readonly IContractRepository _contractRepository;
    
    private readonly IMediator _mediator;

    public DownContractCommandHandler(IContractRepository contractRepository, IMediator mediator)
    {
        _contractRepository = contractRepository;
        _mediator = mediator;
    }

    public async Task<int> Handle(DownContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetAsync(request.Id);
        if (contract == null) throw new Exception($"不存在id为 {request.Id} 的合同");
        contract.DownContract();
        await _contractRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        
        // todo add the order logic
        return contract.Id;
    }
}