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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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