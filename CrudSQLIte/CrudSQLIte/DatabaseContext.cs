using CrudSQLIte.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrudSQLIte
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CycleModel> Cycles { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        // overrides the OnConfigure Method 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Cycle.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
