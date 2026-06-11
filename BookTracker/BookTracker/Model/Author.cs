using System.ComponentModel.DataAnnotations;

namespace BookTracker.Model
{
    public class Author : EFModel
    {
        public string? Biografy { get; set; }
    }
}
