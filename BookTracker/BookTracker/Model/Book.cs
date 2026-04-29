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
        public int Year { get; set; }
        [Required(ErrorMessage = "Выберите жанр.")]
        public int GenreId { get; set; }
        [ValidateNever]
        public Genre? Genre { get; set; }
        public string? Notes {  get; set; }
        public DateTime AddDateTime {  get; set; }
        public BookStatus Status { get; set; }
    }
}
