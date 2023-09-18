using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository: IRepository<Product>
{
    Product Add(Product product);

    Product Update(Product product);

    Task DeleteAsync(int id);
}