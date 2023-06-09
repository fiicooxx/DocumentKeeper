using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;

namespace Web.Pages.Documents
{
    public class CreateModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public CreateModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [BindProperty]
        public Document Document { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _documentRepository.AddDocument(Document);

            return RedirectToPage("Index");
        }
    }
}