using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Main.Models
{
    public class Main
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
    }
    public class LogDBContext : DbContext
    {
        public DbSet<Main> Mains { get; set; }
    }
}