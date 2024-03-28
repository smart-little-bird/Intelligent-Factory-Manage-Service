using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateProductCommand : IRequest<int>
{
    public CreateProductCommand(string description, string entryCriteria, IEnumerable<ProductItemDto> productListItemDtos)
    {
        Description = description;
        EntryCriteria = entryCriteria;
        ProductListItemDtos = productListItemDtos;
    }

    public string Description { get; set; }

    public string EntryCriteria { get; set; }

    public IEnumerable<ProductItemDto> ProductListItemDtos { get; set; }
    
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Description, request.EntryCriteria);
        foreach (var productItemDto in request.ProductListItemDtos)
        {
            product.AddProductItem(productItemDto.ProductType, productItemDto.Name, productItemDto.Specifications, productItemDto.Amount, productItemDto.UnitPrice, productItemDto.Unit, productItemDto.Material, productItemDto.TechnicalRequirements, productItemDto.Remark);
        }
        var result = _productRepository.Add(product);
        await _productRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        return result.Id;
    }
}