using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SearchFill.Data
{
    public class SearchFillContext : IdentityDbContext<IdentityUser>
    {
        public SearchFillContext(DbContextOptions<SearchFillContext> options)
            : base(options)
        {
        }

        public DbSet<SearchFill.Models.Country> Country { get; set; }
        public DbSet<SearchFill.Models.Species> Species { get; set; }

        public DbSet<SearchFill.Models.Person> Person { get; set; }
        public DbSet<SearchFill.Models.Item> Item { get; set; }
        public DbSet<SearchFill.Models.SportItems> SportItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
