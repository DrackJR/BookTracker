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
                return Page();                    

            _context.Books.Update(Book);
            _context.SaveChanges();

            return RedirectToPage("Index");
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
