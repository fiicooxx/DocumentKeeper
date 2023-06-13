using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDocumentRepository
    {
        // (zmiana)List<Document> AddDocument(Document document);
        // To nie ma być lista tylko pojedynczy obiekt , więc niech AddDocument zwraca pojedynczy dokument
        Document AddDocument(Document document);
        // bez zmian
        List<Document> GetAllDocuments();

        // (zmiana) List<Document> GetDocumentById(int id);
        // Tak jak powyżej, niech zwraca tylko jeden dokument, nie listę
        Document GetDocumentById(int id);

        // (zmiana) List<Document> UpdateDocument(int id, Document document);
        // Update powinien się odnosić do całego dokumentu, nie tylko id, chyba
        //Document UpdateDocument(Document document) -> dodaje na wypadek zwykłego wprowadzenia zmiany i wyświetlenia pojedynczego dokumentu po update 
        List<Document> UpdateDocument(Document document);

        // (zmiana) List<Document> DeleteDocument(int id);
        // zaś ta lista
        List<Document> DeleteDocument(int id);

        List<Document> SearchDocumentsByTitle(string title);
    }
}
