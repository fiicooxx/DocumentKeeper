using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Web.Pages.Documents
{
    public class FileModel : PageModel
    {
        public string FileName { get; set; }

        public IActionResult OnGet(string fileName)
        {
            // pobranie informacji o pliku
            var fileModel = GetFileByName(fileName);

            if (fileModel == null)
            {
                return NotFound();
            }

            FileName = fileModel.FileName;

            return Page();
        }

        private FileModel GetFileByName(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            var fileEntity = dbContext.Documents.FirstOrDefault(f => f.Title == fileName);

            if (fileEntity != null)
            {
                var fileModel = new FileModel
                {
                    FileName = fileEntity.Title
                };
                return fileModel;
            }

            return null;
        }
    }
}
