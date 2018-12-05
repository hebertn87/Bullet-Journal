using BuJoApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BuJoApp.DB
{
    public class SqliteDataStore : IDataStore
    {
        private readonly BujoContext context;
        private readonly string dbPath;

        public SqliteDataStore(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new BujoContext(dbPath);
        }

        public void AddTask(Task t)
        {
            context.Tasks.Add(t);
            context.SaveChanges();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return context.Tasks;
        }
    }

    class BujoContext : DbContext
    {
        private static bool _created = false;
        private readonly string dbPath;

        public BujoContext(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));

            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasKey(p => p.TaskID);
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
