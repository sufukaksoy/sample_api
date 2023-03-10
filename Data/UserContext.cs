using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sample_api.Models;

namespace sample_api.Data
{
    public class UserContext : DbContext
    {
        
        public DbSet<User> Users {get; set;}
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1234;Database=mockData");
        }
    }
}