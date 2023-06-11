using Microsoft.AspNetCore.Mvc;

namespace Web.Pages.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
