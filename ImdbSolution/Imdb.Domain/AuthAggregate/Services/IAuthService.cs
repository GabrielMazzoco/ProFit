using IronFit.Domain.AuthAggregate.Dtos;

namespace IronFit.Domain.AuthAggregate.Services
{
    public interface IAuthService
    {
        string Login(LoginDto loginDto);
        string GeneratePasswordHash(string password);
    }
}
