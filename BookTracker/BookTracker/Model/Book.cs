namespace BookTracker.Model
{
    public class Book : EFModel
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
        public string? Notes {  get; set; }
        public DateTime AddDateTime {  get; set; }
        public enum Status {Прочитано, Читаю, В_планах, Отложено }
    }
}
