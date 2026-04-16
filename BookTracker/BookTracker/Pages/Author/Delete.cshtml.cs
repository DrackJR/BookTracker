using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Author
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Author Author { get; set; }

        public IActionResult OnGet(int id)
        {
            Author = _context.Authors.Find(id);

            if (Author == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var author = _context.Authors.Find(Author.Id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
