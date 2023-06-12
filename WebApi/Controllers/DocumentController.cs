using ApplicationCore.Models;
using Azure.Core;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {

        private readonly IDocumentRepository _repository;

        public DocumentController(IDocumentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Document>> AddDocument(Document document)
        {
            var result = _repository.AddDocument(document);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetAllDocuments()
        {
            return _repository.GetAllDocuments();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Document>> GetDocumentById(int id)
        {
            var result = _repository.GetDocumentById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Document>>> UpdateDocument(Document document)
        {
            var result = _repository.UpdateDocument(document);
            if (result == null)
                return NotFound("Document not found");

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Document>>> DeleteDocument(int id)
        {
            var result = _repository.DeleteDocument(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
