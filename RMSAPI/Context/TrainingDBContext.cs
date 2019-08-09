using Microsoft.EntityFrameworkCore;
using RMSAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMSAPI.Context
{
    public class TrainingDBContext : DbContext
    {
        public TrainingDBContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Training> Training { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Training>();
        }
    }
}
