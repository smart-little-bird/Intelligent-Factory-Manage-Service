using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateProductCommand : IRequest<int>
{
    public CreateProductCommand(string description, string entryCriteria)
    {
        Description = description;
        EntryCriteria = entryCriteria;
    }

    public string Description { get; set; }

    public string EntryCriteria { get; set; }

    public IEnumerable<ProductItemDto> ProductItemDtos { get; set; }

    public record ProductItemDto
    {
        /// <summary>
        /// 产品类型Id
        /// </summary>
        public ProductType ProductType { get;  set; }

        /// <summary>
        /// 产品明细名称
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specifications { get;  set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get;  set; }
    
        /// <summary>
        /// 单价
        /// </summary>
        public int UnitPrice { get;  set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get;  set; }

        /// <summary>
        /// 材料型号
        /// </summary>
        public string Material { get;  set; }

        /// <summary>
        /// 技术要求
        /// </summary>
        public string TechnicalRequirements { get;  set; }
    
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get;  set; }
    }
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
        foreach (var productItemDto in request.ProductItemDtos)
        {
            product.AddProductItem(productItemDto.ProductType,productItemDto.Name,productItemDto.Specifications,productItemDto.Amount,productItemDto.UnitPrice,productItemDto.Unit,productItemDto.Material,productItemDto.TechnicalRequirements,productItemDto.Remark);
        }
        var result = _productRepository.Add( product);
        await _productRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
        return result.Id;
    }
}