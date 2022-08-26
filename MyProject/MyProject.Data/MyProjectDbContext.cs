using Microsoft.EntityFrameworkCore;
using MyProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public class MyProjectDbContext:DbContext
    {
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options):base(options)
        {

        }
        public DbSet<Appartment> appartments { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<User> users { get; set; }
    }
}
