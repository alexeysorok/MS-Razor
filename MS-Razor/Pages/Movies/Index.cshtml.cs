using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } //  текст для поиска 

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; } // дает возможность выбрать жанр 

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Поиск по жанру (все жанры)
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
                        
            //добавляем поиск на странице по жанру 
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            // как выглядит строка поиска 
            // https://localhost:5001/Movies?searchString=Ghost 

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies.Where(x => x.Genre == MovieGenre);
            }

            // проецирование отдельных жанров
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
