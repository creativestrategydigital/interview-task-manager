using System.ComponentModel.DataAnnotations;

namespace TaskManager.App.Dto
{
    public class UpdateTaskRequest
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        public bool IsComplete { get; set; }
    }
}