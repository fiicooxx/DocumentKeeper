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

        [HttpGet("{id}")]
        public ActionResult<DocumentDto> GetDocumentById(int id)
        {
            var document = _documentRepository.GetDocumentById(id);
            if (document != null)
                return Ok(DocumentDto.Of(document));
            else
                return NotFound();
        }

        [HttpGet("search")]
        public ActionResult<List<DocumentDto>> SearchDocumentsByTitle(string title)
        {
            var documents = _documentRepository.SearchDocumentsByTitle(title);
            var documentDtos = new List<DocumentDto>();
            foreach (var document in documents)
            {
                documentDtos.Add(DocumentDto.Of(document));
            }
            return documentDtos;
        }


        [HttpPost("create")]
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

        [HttpPut("edit/{id}")]
        public ActionResult<DocumentDto> EditDocument(int id, [FromBody] DocumentDto documentDto)
        {
            if (ModelState.IsValid)
            {
                var existingDocument = _documentRepository.GetDocumentById(id);
                if (existingDocument == null)
                {
                    return NotFound();
                }

                existingDocument.Title = documentDto.Title;
                existingDocument.Description = documentDto.Description;
                existingDocument.Status = documentDto.Status;

                _documentRepository.UpdateDocument(existingDocument);

                var updatedDocumentDto = DocumentDto.Of(existingDocument);

                return Ok(updatedDocumentDto);
            }

            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<DocumentDto> DeleteDocument(int id)
        {
            var document = _documentRepository.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }

            _documentRepository.DeleteDocument(id);

            var documentDto = DocumentDto.Of(document);
            return Ok(documentDto);
        }
    }
}
