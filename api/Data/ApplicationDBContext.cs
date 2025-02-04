using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Data{

    public class ApplicationDBContext : DbContext{

        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Stock> stocks { get; set; }
        public DbSet<Comment> comments { get; set; } 

    }

}