using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Documents
{
    public class FileModel : PageModel
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileContent { get; set; }

        public IActionResult OnGet(string fileName)
        {
            // TODO: Pobraæ informacje o pliku na podstawie nazwy pliku z bazy danych

            // pobranie informacji o pliku
            var file = GetFileByName(fileName);

            if (file == null)
            {
                return NotFound();
            }

            FileName = file.FileName;
            FileSize = file.FileSize;
            FileContent = file.FileContent;

            return Page();
        }

        private FileModel GetFileByName(string fileName)
        {
            // TODO: Pobraæ informacje o pliku na podstawie nazwy pliku z bazy danych

            if (fileName == "example.txt")
            {
                return new FileModel
                {
                    FileName = "Example Name",
                    FileSize = 1024,
                    FileContent = "Lorem ipsum"
                };
            }

            return null;
        }

    }
}
