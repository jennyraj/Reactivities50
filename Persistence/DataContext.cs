using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Activity>()
                .Property(a => a.Id).UseIdentityColumn();
           
            builder.Entity<Activity>()
                .Property(a => a.Title)
                .HasColumnType("varchar(50)");

            builder.Entity<Activity>()
                .Property(a => a.Description)
                .HasColumnType("varchar(50)");
            
            builder.Entity<Activity>()
                .Property(a => a.Category)
                .HasColumnType("varchar(20)");
            
            builder.Entity<Activity>()
                .Property(a => a.City)
                .HasColumnType("varchar(20)");
            
            builder.Entity<Activity>()
                .Property(a => a.Venue)
                 .HasColumnType("varchar(30)");
    
            
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );
        }
    }
}
