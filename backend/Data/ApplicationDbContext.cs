using SDDV5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using SDDV5.Data;
using SDDV5.Models;
using SDDV5.DTOs; 
namespace SDDV5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<VerificationLog> VerificationLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email = "admin@example.com", Password = "Admin123", Role = "Admin" },
                new User { Id = 2, Name = "John Doe", Email = "john@example.com", Password = "User123", Role = "User" }
            );

            
            DateTime staticCreatedAt = new DateTime(2024, 3, 7, 12, 0, 0); 

            
            modelBuilder.Entity<Document>().HasData(
                new Document
                {
                    Id = 1,
                    UserId = 2,
                    Title = "Sample Document",
                    FilePath = "/uploads/sample.pdf",
                    VerificationCode = "ABC12345", 
                    Status = "Pending",
                    CreatedAt = staticCreatedAt
                }
            );
        }
    }
}
