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
}