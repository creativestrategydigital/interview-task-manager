using System.ComponentModel.DataAnnotations;

namespace TaskManager.App.Dto
{
    public class CreateTaskRequest
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        
        public string? Description { get; set; }
    }
}