using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MS_Razor.Models
{
    public class MS_RazorContext : DbContext
    {
        public MS_RazorContext (DbContextOptions<MS_RazorContext> options)
            : base(options)
        {
        }

        public DbSet<MS_Razor.Models.Movie> Movie { get; set; }
    }
}
