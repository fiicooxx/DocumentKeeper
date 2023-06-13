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
        [Route("getall")]
        public IEnumerable<DocumentDto> GetAllDocuments()
        {
            var allDocuments = _documentRepository.GetAllDocuments();
            List<DocumentDto> documentDtos = new();
            foreach (var documentDto in allDocuments)
                documentDtos.Add(DocumentDto.Of(documentDto));
            return documentDtos;
        }

        [HttpGet]
        [Route("getby/{id}")]
        public ActionResult<DocumentDto> GetDocumentById(int id)
        {
            var document = _documentRepository.GetDocumentById(id);
            if (document != null)
                return Ok(DocumentDto.Of(document));
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
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


        [HttpPost]
        [Route("create")]
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

        [HttpDelete]
        [Route("delete/{id}")]
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
