using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SearchFill.Models;

//namespace SearchFill.Data
//{
//    public class SearchFillContext : IdentityDbContext<IdentityUser>
//    {
//        public SearchFillContext (DbContextOptions<SearchFillContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<SearchFill.Models.Country> Country { get; set; }
//        public DbSet<SearchFill.Models.Species> Species { get; set; }

//        public DbSet<SearchFill.Models.Person> Person { get; set; }
//        public DbSet<SearchFill.Models.Item> Item { get; set; }
//        public DbSet<SearchFill.Models.SportItems> SportItems { get; set; }

//        //protected override void OnModelCreating(ModelBuilder modelBuilder)
//        //{
//        //    modelBuilder.Entity<Country>().HasData(
//        //        new Country
//        //        {
//        //            Id = 1,
//        //            Name = "Poland"
//        //        }
//        //    );
//        //}

        
//    }
//}
