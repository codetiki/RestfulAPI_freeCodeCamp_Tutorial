using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace WebAPI.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<ForceType> ForceTypes { get; set; }
        public DbSet<Result> Results { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ForceType>().ToTable("ForceTypes");
            builder.Entity<ForceType>().HasKey(p => p.Id);
            builder.Entity<ForceType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ForceType>().Property(p => p.Type).IsRequired().HasMaxLength(500);
            builder.Entity<ForceType>().HasMany(p => p.Results).WithOne(p => p.ForceType).HasForeignKey(p => p.ForceTypeId);

            builder.Entity<ForceType>().HasData
            (
                new ForceType 
                { 
                    Id = 100, 
                    Type = "Tasainen viivakuorma" 
                }, // Id set manually due to in-memory provider
                new ForceType 
                { 
                    Id = 101, 
                    Type = "Pistekuorma" 
                }
            );

            builder.Entity<Result>().ToTable("Results");
            builder.Entity<Result>().HasKey(p => p.Id);
            builder.Entity<Result>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Result>().Property(p => p.Name).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.LengthL).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.LengthA).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.LengthB).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.ForceTV).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.ForcePK).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.ForcePM).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.MaxM).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.MaxV).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.DateOfJoining).IsRequired().HasMaxLength(500);
            builder.Entity<Result>().Property(p => p.PhotoFileName).IsRequired().HasMaxLength(500);
            // builder.Entity<Result>().HasMany(p => p.ForceTypes).WithOne(p => p.Result).HasForeignKey(p => p.ResultId);

            builder.Entity<Result>().HasData
            (
                new Result 
                { 
                    Id = 1001, 
                    Name = "Eka palkki", 
                    LengthL = "10", 
                    LengthA = "0", 
                    LengthB = "0", 
                    ForceTV = "5", 
                    ForcePK = "0", 
                    ForcePM = "0", 
                    MaxM = "99", 
                    MaxV = "125", 
                    DateOfJoining = "26.02.2022", 
                    PhotoFileName = "palkkikuva.jpg",
                    ForceTypeId = 100
                },
                new Result
                {
                    Id = 1002,
                    Name = "Toka palkki",
                    LengthL = "0",
                    LengthA = "5",
                    LengthB = "3",
                    ForceTV = "0",
                    ForcePK = "12",
                    ForcePM = "0",
                    MaxM = "77",
                    MaxV = "897",
                    DateOfJoining = "27.02.2022",
                    PhotoFileName = "palkkikuva2.jpg",
                    ForceTypeId = 101
                }

            );


        }

    }
}
