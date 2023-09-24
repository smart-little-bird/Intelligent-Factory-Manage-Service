using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class UpdateProductCommand : IRequest<int>
{
    public UpdateProductCommand(int id, string description, string entryCriteria, IEnumerable<ProductItemDto> productItemDtos)
    {
        Id = id;
        Description = description;
        EntryCriteria = entryCriteria;
        ProductItemDtos = productItemDtos;
    }

    [FromRoute]
    public int Id { get; set; }

    public string Description { get; set; }

    public string EntryCriteria { get; set; }

    public IEnumerable<ProductItemDto> ProductItemDtos { get; set; }

}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.Id);
        product.UpdateProduct(request.Description, request.EntryCriteria);
        product.RemoveProductItems();
        foreach (var productItemDto in request.ProductItemDtos)
        {
            product.AddProductItem(productItemDto.ProductType, productItemDto.Name, productItemDto.Specifications, productItemDto.Amount, productItemDto.UnitPrice, productItemDto.Unit, productItemDto.Material, productItemDto.TechnicalRequirements, productItemDto.Remark);
        }
        var result = _productRepository.Update(product);
        await _productRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        return result.Id;
    }
}