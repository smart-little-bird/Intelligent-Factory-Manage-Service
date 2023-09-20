using AutoMapper;
using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ProductQueries : IProductQueries
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public ProductQueries(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductPageDto> GetProductListAsync(int pageIndex, int pageSize)
    {
        var products = await _productRepository.GetListWithPageAsync(pageIndex, pageSize);
        var productListDtos = products.Select(t => _mapper.Map<ProductListDto>(t));
        var total = await _productRepository.GetCount();
        return new ProductPageDto(productListDtos, new Page
        {
            PageSize = pageSize,
            PageIndex = pageIndex,
            Total = total
        });
    }
    
    public async Task<IEnumerable<ProductListDto>> GetProductListAsync()
    {
        var products = await _productRepository.GetListAsync();
        return products.Select(t => _mapper.Map<ProductListDto>(t));
    }
}