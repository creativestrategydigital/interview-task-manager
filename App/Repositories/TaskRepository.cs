using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace TaskManager.App.Repositories
{
    public class TaskRepository
    {
        private readonly AppDbContext _db = new AppDbContext();

        public IEnumerable<Entities.Task> FetchAll(int userId)
        {
            return _db.Tasks.Where(_task => _task.UserId == userId).ToList();
        }

        public Entities.Task? Fetch(int taskId, int userId)
        {
            return _db.Tasks
                .Where(_task => _task.Id == taskId)
                .SingleOrDefault(_task => _task.UserId == userId);
        }
        
        public Entities.Task Save(Entities.Task task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();

            return task;
        }

        public Entities.Task Update(Entities.Task task)
        {
            _db.Tasks.Update(task);
            _db.SaveChanges();

            return task;
        }

        public void Delete(Entities.Task task)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
    }
}