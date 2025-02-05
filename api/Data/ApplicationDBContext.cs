using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace api.Data{

    public class ApplicationDBContext : IdentityDbContext<AppUser>{

        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions){}

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
            builder.Entity<Portfolio>(x => x.HasKey(p => new {p.AppUserId, p.StockId}));

            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);
            
            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>{
                new () {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new () {
                    Name = "User",
                    NormalizedName = "User"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }

    }

}