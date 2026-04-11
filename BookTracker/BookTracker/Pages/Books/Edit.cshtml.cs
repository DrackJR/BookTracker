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
                LoadSelectLists();
                return Page();
            }
            var existingBook = _context.Books
               .Include(b => b.Author)
               .Include(b => b.Genre)
               .FirstOrDefault(b => b.Id == Book.Id);

            if (existingBook == null)
                return NotFound();

            existingBook.Title = Book.Title;
            existingBook.Year = Book.Year;
            existingBook.Notes = Book.Notes;
            existingBook.Status = Book.Status;
            existingBook.AddDateTime = Book.AddDateTime;

            if (Book.Author != null && Book.Author.Id > 0)
            {
                existingBook.Author = _context.Authors.Find(Book.Author.Id);
            }
            else
            {
                existingBook.Author = null;
            }

            if (Book.Genre != null && Book.Genre.Id > 0)
            {
                existingBook.Genre = _context.Genres.Find(Book.Genre.Id);
            }
            else
            {
                existingBook.Genre = null;
            }

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
