using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;

namespace Web.Pages.Documents
{
    public class DeleteModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public DeleteModel(IDocumentRepository documentRepository)
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
            var document = _documentRepository.GetDocumentById(id);

            if (document == null)
            {
                return NotFound();
            }

            _documentRepository.DeleteDocument(document);

            return RedirectToPage("Index");
        }
    }
}