using ComprasDotnet6.Domain.Entities;
using ComprasDotnet6.Domain.Interfaces;
using ComprasDotnet6.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ComprasDotnet6.Infra.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _context.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _context.Remove(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Purchase purchase)
        {
            _context.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            var purchase = await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return purchase;
        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            return await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.PersonId == personId).ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            return await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {
            return await _context.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .ToListAsync();
        }
    }
}
