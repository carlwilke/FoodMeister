using System;
using System.Collections.Generic;
using System.Text;
using FoodMeister.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodMeister.Data
{
    public class FoodMeisterDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
