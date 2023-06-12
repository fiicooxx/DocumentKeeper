using ApplicationCore.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using ApplicationCore.Models;

public class SearchModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public List<Document> SearchResults { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchQuery { get; set; }

    public SearchModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        if (!string.IsNullOrEmpty(SearchQuery))
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                // Przeszukaj wszystkie dokumenty
                SearchResults = _context.Documents
                    .Where(d => d.Title.Contains(SearchQuery) || d.Description.Contains(SearchQuery))
                    .ToList();
            }
            else
            {
                // Ogranicz wyszukiwanie tylko do dokumentów publicznych
                SearchResults = _context.Documents
                    .Where(d => d.Status == DocumentStatus.Public && (d.Title.Contains(SearchQuery) || d.Description.Contains(SearchQuery)))
                    .ToList();
            }
        }
    }
}