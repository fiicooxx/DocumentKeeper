using ApplicationCore.Enums;
using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Document AddDocument(Document document)
        {
            _context.Documents.Add(document);
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
                existingDocument.FileType = document.FileType;
                existingDocument.Description = document.Description;
                existingDocument.Status = document.Status;
            }
            _context.SaveChanges();
            return _context.Documents.ToList();
        }

        public void DeleteDocument(int id)
        {
            var document = _context.Documents.Find(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
                _context.SaveChanges();
            }
        }

        public void DeleteDocument(List<Document> documents)
        {
            _context.Documents.RemoveRange(documents);
            _context.SaveChanges();
        }

        public Document SearchDocumentsByTitle(string title)
        {
            // Logika wyszukiwania dokumentów po tytule
            return (Document)_context.Documents.Where(d => d.Title.Contains(title));
        }
    }
}


