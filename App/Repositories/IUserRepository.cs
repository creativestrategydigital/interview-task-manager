using TaskManager.App.Entities;

namespace TaskManager.App.Repositories
{
    public interface IUserRepository
    {
        public User? FindByEmail(string email);

        public void Save(User user);
    }
}