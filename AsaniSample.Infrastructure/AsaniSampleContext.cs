using System;
using System.Collections.Generic;
using AsaniSample.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsaniSample.Infrastructure
{
   public class AsaniSampleContext : DbContext
    {
        public AsaniSampleContext(DbContextOptions<AsaniSampleContext> options):base(options)
        {

        }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(new List<Owner>()
            {
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "علی",
                    LastName = "احمدی",
                    Phone = "09122233223"
                },
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "فاطمه",
                    LastName = "اسدی",
                    Phone = "09128877665"
                }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
