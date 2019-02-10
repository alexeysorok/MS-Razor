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

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Дата Выпуска")] // отображаемое имя 
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } // пользователю не требуется вводить сведения о времени 
                                                  //в поле даты. Отображается только дата, а не время

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] // должна начинаться с одной или нескольких заглавных букв, после чего могут следовать ноль или несколько букв, двойных или одинарных кавычек, пробелов или дефисов
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)] // ограничивает диапазон значений 
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18, 2)")] // позволяет Entity Framework Core корректно сопоставить Price с валютой в базе данных
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required] // должно иметь значение
        public string Rating { get; set; }
    }
}
