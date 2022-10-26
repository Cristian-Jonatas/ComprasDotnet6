using ComprasDotnet6.Domain.Entities;

namespace ComprasDotnet6.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string pass);
    }
}
