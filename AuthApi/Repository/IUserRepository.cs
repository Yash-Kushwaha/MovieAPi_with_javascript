using AuthApi.Models;

namespace AuthApi.Repository
{
    public interface IUserRepository
    {
        int Register(User user);
        User Login(string userName, string password);
    }
}
