using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Interfaces;
using ApplicationCore.Models;
using System.Collections.Generic;

namespace Web.Pages.Documents
{
    public class SearchModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public SearchModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public List<Document> Documents { get; set; }

        public void OnGet(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Documents = _documentRepository.SearchDocumentsByTitle(title);
            }
        }
    }
}