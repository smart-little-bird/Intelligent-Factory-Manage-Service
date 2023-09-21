using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateContractCommand: IRequest<int>
{
    public CreateContractCommand(int clientId, string clientName, string phone)
    {
        ClientId = clientId;
        ClientName = clientName;
        Phone = phone;
    }

    public int ClientId { get; set; }

    public string ClientName { get; set; }

    public string Phone { get; set; }

    public record ContractItemDto
    {
        public ProductType ProductType { get; set; }
    }
}

public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, int>
{
    public Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
