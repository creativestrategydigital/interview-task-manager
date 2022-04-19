using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManager.App.Entities
{
    [Table("tasks")]
    public class Task : BaseEntity
    {
        [Column("id")] 
        public int Id { get; set; }
        
        [Column("title", TypeName="varchar(255)")]
        public string Title { get; set; }
        
        [Column("description", TypeName = "text")] 
        public string? Description { get; set; }
        
        [Column("is_complete", TypeName = "int")] 
        public bool? IsComplete { get; set; }
        
        [Column("userId")]
        public int UserId { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        
        public User Owner { get; set; }
    }
}