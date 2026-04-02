using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookTracker.Data;
using BookTracker.Model;


namespace BookTracker.Pages.Author
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Author> Authors { get; set; }

        public void OnGet()
        {
            Authors = _context.Books.ToList();
        }
    }
}
