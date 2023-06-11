using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Web.Pages.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DocumentController : Controller
    {
        // Akcja wyświetlająca listę dokumentów
        [AllowAnonymous] // Dostępna dla wszystkich użytkowników
        public IActionResult Index()
        {
            List<Document> documents = GetDocumentsFromDatabase();
            return View(documents);
        }

        [AllowAnonymous]
        public IActionResult File()
        {
            return View(); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Document document)
        {
            // TODO: Logika zapisu dokumentu do bazy danych

            // Przekierowanie na stronę z listą dokumentów
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Logika usuwania dokumentu z bazy danych

            // Przekierowanie na stronę z listą dokumentów
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // Logika pobierania dokumentu z bazy danych na podstawie identyfikatora id

            // Sprawdzenie czy dokument istnieje

            // Jeśli dokument nie istnieje, zwróć NotFound()

            // Jeśli dokument istnieje, przekaz go do widoku edycji
            Document document = GetDocumentById(id);
            return View(document);
        }

        [HttpPost]
        public IActionResult Edit(Document document)
        {
            // Logika edycji dokumentu w bazie danych

            // Przekierowanie na stronę z listą dokumentów
            return RedirectToAction("Index");
        }

        private List<Document> GetDocumentsFromDatabase()
        {
            // Implementacja logiki pobierania dokumentów z bazy danych
            // Zwróć listę dokumentów
            return new List<Document>();
        }

        // Metoda pomocnicza do pobrania dokumentu z bazy danych na podstawie identyfikatora
        private Document GetDocumentById(int id)
        {
            // Implementacja logiki pobierania dokumentu z bazy danych na podstawie id
            // Zwróć dokument lub null, jeśli nie istnieje
            return null;
        }
    }
}
