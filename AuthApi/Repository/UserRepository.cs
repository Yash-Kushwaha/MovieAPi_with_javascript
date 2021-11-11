using AuthApi.Models;
using System.Linq;

namespace AuthApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext db;

        public UserRepository(UserDbContext db)
        {
            this.db = db;
        }

        public User Login(string userName, string password)
        {
            return db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
        }

        public int Register(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }
    }
}
