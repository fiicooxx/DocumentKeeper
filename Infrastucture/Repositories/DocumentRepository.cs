using ApplicationCore.Enums;
using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Document AddDocument(Document document)
        {
            _context.Documents.Add(document);
            var operation = new OperationHistory
            {
                DocumentId = document.Id,
                Type = DocumentOperationType.Add,
                Timestamp = DateTime.Now
            };
            _context.OperationHistories.Add(operation);
            _context.SaveChanges();
            return document;
        }

        public List<Document> GetAllDocuments()
        {
            return _context.Documents.ToList();
        }

        public Document GetDocumentById(int id)
        {
            return _context.Documents.FirstOrDefault(d => d.Id == id);
        }

        public List<Document> UpdateDocument(Document document)
        {
            var existingDocument = _context.Documents.Find(document.Id);
            if (existingDocument != null)
            {
                existingDocument.Title = document.Title;
                existingDocument.Description = document.Description;
                existingDocument.Status = document.Status;
            }
            _context.SaveChanges();
            return _context.Documents.ToList();
        }

        public List<Document> DeleteDocument(int id)
        {
            var document = _context.Documents.Find(id);
            if (document is null)
                return null;
            _context.Documents.Remove(document);
            var operation = new OperationHistory
            {
                DocumentId = document.Id,
                Type = DocumentOperationType.Delete,
                Timestamp = DateTime.Now
            };
            _context.OperationHistories.Add(operation);
            _context.SaveChanges();
            return _context.Documents.ToList();
        }

        public List<Document> SearchDocumentsByTitle(string title)
        {
            return _context.Documents.Where(d => d.Title.Contains(title)).ToList();
        }
    }
}


