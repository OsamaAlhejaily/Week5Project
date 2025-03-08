using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SDDV5.DTOs
{
    public class DocumentUploadDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public IFormFile File { get; set; } 
    }
}
