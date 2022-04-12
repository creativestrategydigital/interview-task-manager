using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskManager.App.Entities;

namespace TaskManager.App
{
    public class AppDbContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source=database.sqlite");

    }
}