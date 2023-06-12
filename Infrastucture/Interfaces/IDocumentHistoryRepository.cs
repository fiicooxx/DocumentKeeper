using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Enums;

namespace Infrastructure.Interfaces
{
    public interface IDocumentHistoryRepository
    {
        void LogDocumentOperation(string userId, int documentId, DocumentOperationType operationType);
    }
}
