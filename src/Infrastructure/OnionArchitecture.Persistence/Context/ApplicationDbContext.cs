﻿using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Context;

public class ApplicationDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Pen",
                Value = 10,
                Quantity = 100
            },

               new Product()
               {
                   Id = Guid.NewGuid(),
                   Name = "Paper A4",
                   Value = 1,
                   Quantity = 200
               },

                  new Product()
                  {
                      Id = Guid.NewGuid(),
                      Name = "Book",
                      Value = 30,
                      Quantity = 500
                  }

            );


        base.OnModelCreating(modelBuilder);
    }
}
