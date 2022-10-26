using ComprasDotnet6.Application.DTOs;

namespace ComprasDotnet6.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO);
    }
}
