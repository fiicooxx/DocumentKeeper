using ApplicationCore.Models;
using Azure.Core;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Controllers
{
    [Route("api/v1/documents")]
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public IEnumerable<DocumentDto> GetAllDocuments()
        {
            var allDocuments = _documentRepository.GetAllDocuments();
            List<DocumentDto> documentDtos = new();
            foreach (var documentDto in allDocuments)
                documentDtos.Add(DocumentDto.Of(documentDto));
            return documentDtos;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DocumentDto> GetDocumentById(int id)
        {
            var document = _documentRepository.GetDocumentById(id);
            if (document != null)
                return Ok(DocumentDto.Of(document));
            else
                return NotFound();
        }

    }
}
