﻿using BB103_First_FrontoBack.Models;
using Microsoft.EntityFrameworkCore;

namespace BB103_First_FrontoBack.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        



    }
}
