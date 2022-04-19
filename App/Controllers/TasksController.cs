using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskManager.App.Authorization;
using TaskManager.App.Dto;
using TaskManager.App.Services;

namespace TaskManager.App.Controllers
{
    [AuthenticationRequired]
    [Route("api/tasks")]
    [ApiController]
    public class TasksController: ControllerBase
    {
        private readonly TaskService _taskService = new TaskService();
        
        [HttpGet]
        public IEnumerable<Entities.Task> FetchAll()
        {
            return _taskService.FetchAll();
        }
        
        [HttpGet("{taskId}")]
        public Entities.Task FetchOne(int taskId)
        {
            return _taskService.Fetch(taskId);
        }
        

        [HttpPost]
        public ActionResult Store([FromBody] CreateTaskRequest request)
        {
            var task = _taskService.CreateNewTask(request);
            return Ok(task);
        }
        
        [HttpPut("{taskId}")]
        public Entities.Task Update(int taskId, [FromBody] UpdateTaskRequest request)
        {
            return _taskService.Update(taskId, request);
        }
        
        [HttpDelete("{taskId}")]
        public ActionResult Delete(int taskId)
        {
            _taskService.Delete(taskId);

            return NoContent();
        }
    }
}