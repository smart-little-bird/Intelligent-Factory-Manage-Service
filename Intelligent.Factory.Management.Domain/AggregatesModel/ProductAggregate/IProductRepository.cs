using System.Runtime.InteropServices.ComTypes;
using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> GetAsync(int id);
    
    Product Add(Product product);

    Product Update(Product product);

    Task DeleteAsync(int id);

    Task<List<Product>> GetListWithPageAsync(int pageIndex, int pageSize);

    Task<List<Product>> GetListAsync();
    
    Task<int> GetCount();
}