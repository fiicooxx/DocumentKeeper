using Microsoft.AspNetCore.Http;
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

            var existingDocument = _documentRepository.GetDocumentById(Document.Id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            if (Document != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    existingDocument.Title = Document.Title;
                    existingDocument.Description = Document.Description;
                    existingDocument.Status = Document.Status;
                    existingDocument.Content = memoryStream.ToArray();
                }
            }

            _documentRepository.UpdateDocument(existingDocument);

            return RedirectToPage("../Index");
        }
    }
}