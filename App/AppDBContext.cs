using Microsoft.EntityFrameworkCore;
using TaskManager.App.Entities;

namespace TaskManager.App
{
    public class AppDbContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}