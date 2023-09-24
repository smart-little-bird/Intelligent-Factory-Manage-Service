using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{

    private readonly IProductRepository _productRepository;

    private readonly ILogger<DeleteProductCommandHandler> _logger;

    public DeleteProductCommandHandler(IProductRepository productRepository, ILogger<DeleteProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return _productRepository.DeleteAsync(request.Id);
    }
}