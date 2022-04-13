using System.Linq;
using TaskManager.App.Entities;

namespace TaskManager.App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db = new AppDbContext();

        public User? FindByEmail(string email)
        {
            return _db.Users.FirstOrDefault(user => user.Email == email);
        }
        
        public void Save(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}