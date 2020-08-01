using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchFill.Models;

namespace SearchFill.Data
{
    public class SearchFillContext : DbContext
    {
        public SearchFillContext (DbContextOptions<SearchFillContext> options)
            : base(options)
        {
        }

        public DbSet<SearchFill.Models.Country> Country { get; set; }

        public DbSet<SearchFill.Models.Person> Person { get; set; }
    }
}
