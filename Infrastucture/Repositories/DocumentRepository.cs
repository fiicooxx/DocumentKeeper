using ApplicationCore.Enums;
using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Document> AddDocument(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
            return _context.Documents.ToList();
        }

        public List<Document> GetAllDocuments()
        {
            return _context.Documents.ToList();
        }

        public List<Document> GetDocumentById(int id)
        {
            return _context.Documents.Where(d => d.Id == id).ToList();
        }

        public List<Document> UpdateDocument(int id, Document document)
        {
            var existingDocument = _context.Documents.Find(id);
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

        public List<Document> DeleteDocument(int id)
        {
            var document = _context.Documents.Find(id);
            if (document != null)
            {
                _context.Remove(document);
            }
            _context.SaveChanges();
            return _context.Documents.ToList();
        }
    }
}


