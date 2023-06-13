using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Repositories;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages.Documents
{
<<<<<<< HEAD
=======
    [Authorize(Roles = "admin")]
>>>>>>> cac645df26c3738d762c616fb889f2e311e8e138
    public class DeleteModel : PageModel
    {
        private readonly IDocumentRepository _documentRepository;

        public Document Document { get; set; }

        public DeleteModel(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public IActionResult OnGet(int id)
        {
            Document = _documentRepository.GetDocumentById(id);

            if (Document == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Document = _documentRepository.GetDocumentById(id);

            if (Document == null)
            {
                return NotFound();
            }

            _documentRepository.DeleteDocument(id);

            return RedirectToPage("../Index");
        }
    }
}