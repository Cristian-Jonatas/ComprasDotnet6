using ComprasDotnet6.Domain.Entities;
using ComprasDotnet6.Domain.Interfaces;
using ComprasDotnet6.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ComprasDotnet6.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> GetIdByCodErpAsync(string codErp)
        {
            return (await _context.Products.FirstOrDefaultAsync(p=> p.CodErp == codErp))?.Id ?? 0;
        }

    }
}
