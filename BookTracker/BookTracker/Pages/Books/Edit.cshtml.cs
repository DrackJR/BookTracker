using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public SelectList AuthorList { get; set; }
        public SelectList GenreList { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _context.Books
                .Where(c => c.Id == id)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefault();

            if (Book == null)
                return NotFound();

            LoadSelectLists();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                AuthorList = new SelectList(_context.Authors.ToList(), "Id", "Name");
                GenreList = new SelectList(_context.Genres.ToList(), "Id", "Name");
                return Page();
            }

            _context.Attach(Book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == Book.Id)) return NotFound();
                else throw;
            }

            return RedirectToPage("./Index");
        }


        private void LoadSelectLists()
        {
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();

            AuthorList = new SelectList(authors, "Id", "Name", Book.Author?.Id);
            GenreList = new SelectList(genres, "Id", "Name", Book.Genre?.Id);
        }
    }
}
