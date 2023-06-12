using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class OperationHistory
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DocumentOperationType Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
