using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.App.Controllers
{
    public class TasksController: ControllerBase
    {
        public IEnumerable<Entities.Task> FetchAll()
        {
            return new List<Entities.Task>();
        }
    }


    public class Person
    {
        public string Name { get; set; }
    }
}