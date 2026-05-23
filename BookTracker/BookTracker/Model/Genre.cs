using System.ComponentModel.DataAnnotations;

namespace BookTracker.Model
{
    public class Genre : EFModel
    {
        [Required(ErrorMessage = "Наименование обязательно.")]
        public string Title { get; set; }
        public string? Description {  get; set; }
    }
}
