using ApplicationCore.Enums;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class OperationHistoryDto
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DocumentOperationType Type { get; set; }
        public DateTime Timestamp { get; set; }

        public static OperationHistoryDto Of(OperationHistory operationHistory)
        {
            return new OperationHistoryDto
            {
                Id = operationHistory.Id,
                DocumentId = operationHistory.DocumentId,
                Type = operationHistory.Type,
                Timestamp = operationHistory.Timestamp
            };
        }
    }
}
