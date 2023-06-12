using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using System.IO;
using ApplicationCore.Enums;

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
            if (DocumentFile != null && DocumentFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    DocumentFile.CopyTo(memoryStream);
                    var document = new Document
                    {
                        Title = DocumentFile.FileName,
                        FileType = DocumentFile.ContentType,
                        Content = memoryStream.ToArray(),
                        Description = "dsadasd",
                        CreationDate = DateTime.Now,
                        Status = DocumentStatus.Public,
                        CreatedBy = "admin"
                    };

                    _documentRepository.AddDocument(document);
                }
            }

            return RedirectToPage("Create");
        }
    }
}