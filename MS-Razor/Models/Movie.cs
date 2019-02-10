using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MS_Razor.Models
{
    public class Movie
    {
        public int ID { get; set; } // Primary Key in DB
        public string Title { get; set; }

        [Display(Name = "Дата выпуска")] // отображаемое имя 
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } // пользователю не требуется вводить сведения о времени 
        //в поле даты. Отображается только дата, а не время
        public string Genre { get; set; }

        [Column(TypeName ="decimal(18, 2)")] // позволяет Entity Framework Core корректно сопоставить Price с валютой в базе данных
        public decimal Price { get; set; }

        public string Rating { get; set; }
    }
}
