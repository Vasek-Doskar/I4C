﻿using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MauiApp1.Data
{

    public class Context : DbContext
    {
        public Context() {
            Database.EnsureCreated();
            Batteries_V2.Init(); // nutno pro MAUI
        }

        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            Batteries_V2.Init(); // nutno pro MAUI
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source = I4C.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Person d1 = new Person { Id = 1, Name = "Adam West" };

            Car mazda = new() { Id = 1, Brand = "Mazda", Model = "Atenza", UserId = 1 };
            Car opel = new() { Id = 2, Brand = "Opel", Model = "Corsa D", UserId = 1 };

            modelBuilder.Entity<Person>().HasData(d1);
            modelBuilder.Entity<Car>().HasData(mazda,opel);
        }
    }
}