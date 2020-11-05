using AsaniSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaniSample.DataAccess
{
   public class AsaniSampleContext : DbContext
    {
        public AsaniSampleContext(DbContextOptions<AsaniSampleContext> options):base(options)
        {

        }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Owner> Owners { get; set; }

       
    }
}
