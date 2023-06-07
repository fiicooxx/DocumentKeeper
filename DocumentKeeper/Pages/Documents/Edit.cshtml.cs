using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using System.Reflection.Metadata;

namespace Web.Pages.Documents
{
    public class EditModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public EditModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public IActionResult OnGet(int id)
        {
            var document = _documentRepository.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var document = _documentRepository.GetDocumentById(id);

            _documentRepository.UpdateDocument(document);

            return RedirectToPage("Index");
        }
    }
}