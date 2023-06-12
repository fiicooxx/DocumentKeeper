using ApplicationCore.Enums;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Web.Pages.Documents
{
    public class OperationHistoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<OperationHistory> OperationHistories { get; set; }

        public OperationHistoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            OperationHistories = _context.OperationHistories.ToList();
        }
    }
}
