using System.ComponentModel.DataAnnotations;

namespace BookTracker.Model
{
    public class Author : EFModel
    {
        [Required(ErrorMessage = "Наименование обязательно.")]
        public string Title { get; set; }
        public string? Biografy { get; set; }
    }
}
