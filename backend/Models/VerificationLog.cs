using System;
using System.ComponentModel.DataAnnotations;

namespace SDDV5.Models
{
    public class VerificationLog
    {
        public int Id { get; set; }
        
        [Required]
        public int DocumentId { get; set; }
        
        public Document Document { get; set; }
        
        [Required]
        public string VerifiedBy { get; set; } 
        
        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
        [Required]
        public string Status { get; set; } 
    }
}
