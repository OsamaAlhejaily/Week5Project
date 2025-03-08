using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDDV5.Models
{
    public class Document
    {
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string FilePath { get; set; } 
        
        public string VerificationCode { get; set; } 
        
        public string Status { get; set; } 
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
