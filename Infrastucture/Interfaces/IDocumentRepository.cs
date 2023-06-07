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
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocumentById(int id);
        bool AddDocument(Document document);
        bool UpdateDocument(int id);
        bool DeleteDocument(int id);
    }
}
