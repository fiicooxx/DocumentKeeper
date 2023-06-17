using ApplicationCore.Dtos;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/history")]
    public class OperationHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OperationHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperationHistoryDto>> GetAllOperationHistories()
        {
            var operationHistories = _context.OperationHistories.ToList();
            var operationHistoryDtos = new List<OperationHistoryDto>();

            foreach (var operationHistory in operationHistories)
            {
                operationHistoryDtos.Add(OperationHistoryDto.Of(operationHistory));
            }

            return operationHistoryDtos;
        }
    }
}
