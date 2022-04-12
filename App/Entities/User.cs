using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.App.Entities
{
    [Table("users")]
    [Index("email", IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        
        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; }
        
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }
        
        [Column("apiToken", TypeName = "varchar(255)")]
        public string ApiToken { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public Entities.Task Tasks { get; set; }
    }
}