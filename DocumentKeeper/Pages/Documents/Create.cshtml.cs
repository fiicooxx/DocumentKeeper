using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using System.IO;
using System.Threading.Tasks;
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

        [BindProperty]
        public IFormFile DocumentFile { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (DocumentFile != null && DocumentFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await DocumentFile.CopyToAsync(memoryStream);
                    Document.Content = memoryStream.ToArray();
                    Document.Title = DocumentFile.FileName;
                }
            }

            _documentRepository.AddDocument(Document);

            return RedirectToPage("Index");
        }
    }
}