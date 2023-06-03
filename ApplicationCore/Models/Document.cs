using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DocumentStatus Status { get; set; }
    }
}
