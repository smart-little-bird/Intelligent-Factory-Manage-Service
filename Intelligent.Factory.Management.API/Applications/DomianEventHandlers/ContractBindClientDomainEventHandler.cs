using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Intelligent.Factory.Management.Domain.Event;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.DomianEventHandlers;

public class ContractBindClientDomainEventHandler : INotificationHandler<ContractBindClientDomainEvent>
{
    private readonly IClientRepository _clientRepository;

    public ContractBindClientDomainEventHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task Handle(ContractBindClientDomainEvent notification, CancellationToken cancellationToken)
    {
        var existClient = await _clientRepository.FindByIdAsync(notification.ClientId);
        if (existClient is null)
        {
            var client = new Client(ClientType.Enterprise, notification.ClientName);
            client.AddAddress(notification.Street, notification.City, notification.Province, string.Empty);
            client.AddBank(string.Empty, notification.BankAccount);
            client.InitEnterpriseClient(notification.ClientName, notification.Phone);
            _clientRepository.Add(client);
            await _clientRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}