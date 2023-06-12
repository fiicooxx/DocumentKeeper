using ApplicationCore.Enums;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DocumentHistoryRepository : IDocumentHistoryRepository
    {
        private readonly ILogger<DocumentHistoryRepository> _logger;

        public DocumentHistoryRepository(ILogger<DocumentHistoryRepository> logger)
        {
            _logger = logger;
        }

        public void LogDocumentOperation(string userId, int documentId, DocumentOperationType operationType)
        {
            string operation = operationType == DocumentOperationType.Add ? "Added" : "Deleted";
            string message = $"User '{userId}' {operation} document with ID '{documentId}' at {DateTime.Now}";

            _logger.LogInformation(message);
        }
    }
}
