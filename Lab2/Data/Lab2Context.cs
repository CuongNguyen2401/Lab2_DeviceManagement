using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;

namespace Lab2.Data
{
    public class Lab2Context : DbContext
    {
        public Lab2Context(DbContextOptions<Lab2Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Lab2.Models.Device> Device { get; set; } = default!;
        public DbSet<Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Lab2.Models.User> User { get; set; } = default!;
    }
}
