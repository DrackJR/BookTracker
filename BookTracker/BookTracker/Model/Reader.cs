using System.ComponentModel.DataAnnotations;

namespace BookTracker.Model
{
    public class Reader : EFModel
    {
        [Required(ErrorMessage = "Необходимо заполнить имя")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book>? Books { get; set; }
    }
}
