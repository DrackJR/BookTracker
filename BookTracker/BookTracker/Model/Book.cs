using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookTracker.Model
{
    public class Book : EFModel
    {
        //public string Title { get; set; }
        [Required(ErrorMessage = "Выберите автора.")]
        public int AuthorId { get; set; }
        [ValidateNever]
        public Author? Author { get; set; }
        [Required(ErrorMessage = "Требуется год выпуска.")]
        [Range(1000, 2100, ErrorMessage = "Год должен быть между 1000 и 2100.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Выберите жанр.")]
        public int GenreId { get; set; }
        [ValidateNever]
        public Genre? Genre { get; set; }
        public string? Notes {  get; set; }
        [Required(ErrorMessage = "Требуется дата.")]
        public DateTime AddDateTime {  get; set; }
        [Required(ErrorMessage = "Выберите статус.")]
        public BookStatus Status { get; set; }
    }
}
