using ApplicationCore.Enums;

namespace ApplicationCore.Models
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DocumentStatus Status { get; set; }

        public static DocumentDto Of(Document document)
        {
            return new DocumentDto
            {
                Id = document.Id,
                Content = document.Content,
                Title = document.Title,
                FileType = document.FileType,
                Description = document.Description,
                CreationDate = document.CreationDate,
                CreatedBy = document.CreatedBy,
                Status = document.Status
            };
        }
    }
}
