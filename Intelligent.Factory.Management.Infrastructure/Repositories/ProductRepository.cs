using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Intelligent.Factory.Management.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Intelligent.Factory.Management.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IntelligentFactoryManagementContext _context;

    public ProductRepository(IntelligentFactoryManagementContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Task<Product> GetAsync(int id)
    {
        return _context.Products.Include(t => t.ProductItems).FirstAsync(p => p.Id == id);
    }

    public Product Add(Product product)
    {
        return _context.Products.Add(product).Entity;
    }

    public Product Update(Product product)
    {
        return _context.Products.Update(product).Entity;
    }

    public async Task DeleteAsync(int id)
    {
        _context.Products.Remove(
            (await _context.Products.SingleOrDefaultAsync(t => t.Id == id))!
        );
    }

    public Task<List<Product>> GetListWithPageAsync(int pageIndex, int pageSize)
    {
        return _context.Products.Include(t => t.ProductItems).OrderBy(p => p.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
    }

    public Task<List<Product>> GetListAsync()
    {
        return _context.Products.Include(t => t.ProductItems).OrderBy(p => p.Id).ToListAsync();
    }

    public Task<int> GetCount()
    {
        return _context.Products.CountAsync();
    }
}