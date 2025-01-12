using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Lab2.Models;
using Lab2.Data;

namespace Lab2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Lab2Context(
                serviceProvider.GetRequiredService<DbContextOptions<Lab2Context>>()))
            {
                if (!context.Category.Any() && !context.Device.Any())
                {
                    context.Category.AddRange(
                        new Category
                        {
                            Name = "Electronics",
                            Description = "Devices and gadgets",
                            Devices = new List<Device>()
                        },
                        new Category
                        {
                            Name = "Furniture",
                            Description = "Chairs, tables, and more",
                            Devices = new List<Device>()
                        },
                        new Category
                        {
                            Name = "Stationery",
                            Description = "Office supplies and accessories",
                            Devices = new List<Device>()
                        }
                    );

                    context.SaveChanges();
                }


                var electronics = context.Category.First(c => c.Name == "Electronics");
                var furniture = context.Category.First(c => c.Name == "Furniture");

                context.Device.AddRange(
                    new Device
                    {
                        Name = "Laptop",
                        Code = "ELEC001",
                        CategoryId = electronics.Id,
                        Status = "Active",
                        DateOfEntry = DateTime.Now
                    },
                    new Device
                    {
                        Name = "Smartphone",
                        Code = "ELEC002",
                        CategoryId = electronics.Id,
                        Status = "Active",
                        DateOfEntry = DateTime.Now.AddDays(-10)
                    },
                    new Device
                    {
                        Name = "Office Chair",
                        Code = "FURN001",
                        CategoryId = furniture.Id,
                        Status = "Inactive",
                        DateOfEntry = DateTime.Now.AddMonths(-1)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
