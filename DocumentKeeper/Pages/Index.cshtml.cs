using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Pages.Documents
{
    public class IndexModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public IndexModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public IEnumerable<Document> Documents { get; set; }

        public void OnGet()
        {
            Documents = _documentRepository.GetAllDocuments();
        }
        public async Task<IActionResult> OnGetSortByTitleAsyncAsc()
        {
            Documents = _documentRepository.GetAllDocumentsSortedByTitleAsc();
            return Page();
        }
        public async Task<IActionResult> OnGetSortByTitleAsyncDesc()
        {
            Documents = _documentRepository.GetAllDocumentsSortedByTitleDesc();
            return Page();
        }
    }
}