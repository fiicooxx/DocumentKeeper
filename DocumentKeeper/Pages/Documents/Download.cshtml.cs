using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using System.IO;

namespace Web.Pages.Documents
{
    public class DownloadModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public DownloadModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public IActionResult OnGet(int id)
        {
            Document document = _documentRepository.GetDocumentById(id);

            if (document == null || document.Content == null)
            {
                return NotFound();
            }

            MemoryStream memoryStream = new MemoryStream(document.Content);
            return File(memoryStream, document.FileType, document.Title);
        }
    }
}