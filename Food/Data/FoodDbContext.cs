using Food.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Data
{
    public class FoodDbContext: DbContext
    {
        // Createing and migrating DB is done with two Commands:
        // $ dotnet ef migrations add initaialCreate -v
        // $ dotnet ef database update -v

        public FoodDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
