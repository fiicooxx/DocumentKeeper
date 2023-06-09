using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDocumentRepository
    {
        List<Document> AddDocument(Document document);
        List<Document> GetAllDocuments();
        List<Document> GetDocumentById(int id);
        List<Document> UpdateDocument(int id, Document document);
        List<Document> DeleteDocument(int id);
        void DeleteDocument(List<Document> document);
    }
}
