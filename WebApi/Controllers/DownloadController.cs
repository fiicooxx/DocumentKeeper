using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/download")]
    public class DownloadController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;

        public DownloadController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet("{id}")]
        public IActionResult DownloadDocument(int id)
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
