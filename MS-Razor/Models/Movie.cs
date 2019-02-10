using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MS_Razor.Models
{
    public class Movie
    {
        public int ID { get; set; } // Primary Key in DB
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } // пользователю не требуется вводить сведения о времени 
        //в поле даты. Отображается только дата, а не время
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
