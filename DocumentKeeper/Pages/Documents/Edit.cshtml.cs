using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;

namespace Web.Pages.Documents
{
    public class EditModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public EditModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [BindProperty]
        public Document Document { get; set; }

        public IActionResult OnGet(int id)
        {
            Document = _documentRepository.GetDocumentById(id);

            if (Document == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _documentRepository.UpdateDocument(Document);

            return RedirectToPage("Index");
        }
    }
}