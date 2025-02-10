using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Data.Model;

namespace TaskList.Data.Base
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options):base(options){ }

        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public  DbSet<Tarefa> TaskList {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
             .HasKey(x => x.Id);
        }
    }
}
