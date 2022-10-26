using ComprasDotnet6.Domain.Entities;

namespace ComprasDotnet6.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
    }
}
