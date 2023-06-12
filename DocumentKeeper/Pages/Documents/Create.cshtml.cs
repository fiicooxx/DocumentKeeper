using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using System.IO;

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

        [BindProperty]
        public IFormFile DocumentFile { get; set; }

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

            if (DocumentFile != null && DocumentFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    DocumentFile.CopyTo(memoryStream);
                    Document.Content = memoryStream.ToArray();
                    Document.Title = DocumentFile.FileName;
                    Document.FileType = DocumentFile.ContentType;
                }
            }

            _documentRepository.AddDocument(Document);
            return RedirectToPage("Index");
        }
    }
}