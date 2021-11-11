using AuthApi.Models;

namespace AuthApi.Service
{
    public interface ITokenGeneratorService
    {
        string GenerateJWTToken(string userid, User role);
    }
}
