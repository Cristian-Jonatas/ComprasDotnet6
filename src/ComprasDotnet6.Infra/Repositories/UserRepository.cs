using ComprasDotnet6.Domain.Entities;
using ComprasDotnet6.Domain.Interfaces;
using ComprasDotnet6.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ComprasDotnet6.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string pass)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == pass);
        }
    }
}
