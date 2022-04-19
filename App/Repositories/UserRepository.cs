using System.Linq;
using TaskManager.App.Entities;

namespace TaskManager.App.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _db = new AppDbContext();

        public User? FindByEmail(string email)
        {
            return _db.Users.FirstOrDefault(user => user.Email == email);
        }

        public User? FindByApiToken(string token)
        {
            return _db.Users.FirstOrDefault(user => user.ApiToken == token);
        }

        public User? FindById(int userId)
        {
            return _db.Users.FirstOrDefault(user => user.Id == userId);
        }
        
        public void Save(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}