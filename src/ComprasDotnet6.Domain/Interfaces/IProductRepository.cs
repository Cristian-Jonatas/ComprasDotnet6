using ComprasDotnet6.Domain.Entities;

namespace ComprasDotnet6.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<ICollection<Product>> GetProductAsync();
        Task<Product> CreateAsync(Product product);
        Task EditAsync(Product product);
        Task DeleteAsync(Product product);
        Task<int> GetIdByCodErpAsync(string codErp);
    }
}
