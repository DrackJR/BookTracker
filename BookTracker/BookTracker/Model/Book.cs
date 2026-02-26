namespace BookTracker.Model
{
    public class Book : EFModel
    {
        public string? Title { get; set; }
        public Author Author { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public string? Notes {  get; set; }
        public DateTime AddDateTime {  get; set; }
        public BookStatus Status { get; set; }
    }
}
