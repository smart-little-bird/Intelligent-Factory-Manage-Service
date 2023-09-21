using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class DeleteClientCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<DeleteClientCommandHandler> _logger;

    public DeleteClientCommandHandler(IClientRepository clientRepository, ILogger<DeleteClientCommandHandler> logger)
    {
        _clientRepository = clientRepository;
        _logger = logger;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _clientRepository.DeleteAsync(request.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }

    }
}