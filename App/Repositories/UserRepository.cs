using System.Linq;
using TaskManager.App.Entities;

namespace TaskManager.App
{
    public class UserRepository
    {
        private readonly AppDbContext _db = new AppDbContext();

        public User? FindByEmail(string email)
        {
            return _db.Users.FirstOrDefault(user => user.Email == email);
        }
        
        public void SaveUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}