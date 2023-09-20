using Intelligent.Factory.Management.API.DTOs;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public interface IProductQueries
{
    Task<ProductPageDto> GetProductListAsync(int pageIndex, int pageSize);

    Task<IEnumerable<ProductListDto>> GetProductListAsync();
}