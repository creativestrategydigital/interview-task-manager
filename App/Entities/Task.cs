using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.App.Entities;


namespace TaskManager.App.Entities
{
    [Table("tasks")]
    public class Task 
    {
        public int Id { get; set; }
        
        [Column("title", TypeName="varchar(255)")]
        public string Title { get; set; }
        
        [Column("description", TypeName = "text")]
        public string? Description { get; set; }
        
        [Column("userId")]
        [ForeignKey("FK_Task_User")]
        public int UserId { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        
        public User Owner { get; set; }
    }
}