using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MS_Razor.Models;

namespace MS_Razor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MS_Razor.Models.MS_RazorContext _context;

        public IndexModel(MS_Razor.Models.MS_RazorContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
