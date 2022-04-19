using System;
using System.Collections.Generic;
using TaskManager.App.Dto;
using TaskManager.App.Entities;
using TaskManager.App.Repositories;

namespace TaskManager.App.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository = new TaskRepository();
        private readonly AuthService _authService = new AuthService();

        public Entities.Task? CreateNewTask(CreateTaskRequest request)
        {
            User user = _authService.CurrentUser();

            if (user is null)
            {
                return null;
            }
            
            Entities.Task task = new Entities.Task()
            {
                Title = request.Title,
                Description = request.Description,
                UserId = user.Id,
                IsComplete = false,
                CreatedAt = DateTime.UtcNow,
            };
            
            return _taskRepository.Save(task);
        }

        public IEnumerable<Entities.Task> FetchAll()
        {
            User user = _authService.CurrentUser();
            return _taskRepository.FetchAll(user.Id);
        }
        
        public Entities.Task? Fetch(int taskId)
        {
            User user = _authService.CurrentUser();
            return _taskRepository.Fetch(taskId, user.Id);
        }
        
        public Entities.Task? Update(int taskId, UpdateTaskRequest request)
        {
            Entities.Task task = Fetch(taskId);

            if (task is null)
            {
                return null;
            }

            task.Title = request.Title;
            task.Description = request.Description;
            task.IsComplete = request.IsComplete;
            
            return _taskRepository.Update(task);
        }

        public void Delete(int taskId)
        {
            Entities.Task task = Fetch(taskId);

            if (task is null)
            {
                return;
            }
            
            _taskRepository.Delete(task);
        }
    }
}