using ApplicationCore.Enums;
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

        [HttpPost]
        public ActionResult<DocumentDto> CreateDocument([FromBody] DocumentDto documentDto)
        {
            if (ModelState.IsValid)
            {
                var document = new Document
                {
                    Id = documentDto.Id,
                    Content = documentDto.Content,
                    Title = documentDto.Title,
                    FileType = documentDto.FileType,
                    Description = documentDto.Description,
                    CreationDate = DateTime.Now,
                    CreatedBy = "Admin",
                    Status = DocumentStatus.Public
                };

                var createdDocument = _documentRepository.AddDocument(document);
                var createdDocumentDto = DocumentDto.Of(createdDocument);

                return Ok(createdDocumentDto); // Zwracanie utworzonego dokumentu w formie DocumentDto
            }

            return BadRequest(); 
        }

    }
}
