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
                AuthorList = new SelectList(_context.Authors.ToList(), "Id", "Name");
                GenreList = new SelectList(_context.Genres.ToList(), "Id", "Name");
                return Page();
            }

            _context.Books.Add(Book);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
