using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Required]
        public DocumentStatus Status { get; set; }

        public Document()
        {
            Status = DocumentStatus.Public;
            CreationDate = DateTime.Now;
        }
    }
}
