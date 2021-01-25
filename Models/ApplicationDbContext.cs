using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikeRent.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public DbSet<Bike> Bikes { get; set; }

        public DbSet<BikeType> BikeTypes { get; set; }
    }
}