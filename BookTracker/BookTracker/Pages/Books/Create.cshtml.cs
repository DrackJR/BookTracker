using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookTracker.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public SelectList AuthorList { get; set; }
        public SelectList GenreList { get; set; }

        public void OnGet() 
        {
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();

            AuthorList = new SelectList(authors, "Id", "Name");
            GenreList = new SelectList(genres, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var authors = _context.Authors.ToList();
                var genres = _context.Genres.ToList();

                AuthorList = new SelectList(authors, "Id", "Name");
                GenreList = new SelectList(genres, "Id", "Name");
                return Page();
            }
            if (Book.Author != null && Book.Author.Id > 0)
            {
                Book.Author = _context.Authors.Find(Book.Author.Id);
            }

            if (Book.Genre != null && Book.Genre.Id > 0)
            {
                Book.Genre = _context.Genres.Find(Book.Genre.Id);
            }
            _context.Books.Add(Book);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
