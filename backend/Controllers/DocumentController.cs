using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDDV5.Data;
using SDDV5.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SDDV5.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        

[HttpPost]
public async Task<IActionResult> UploadDocument([FromForm] string title, [FromForm] IFormFile file)
{
    Console.WriteLine($"Received title: {title}");
    Console.WriteLine($"Received file: {file?.FileName ?? "No file received"}");

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Error: Title is missing");
        return BadRequest(new { error = "Title is required." });
    }

    if (file == null || file.Length == 0)
    {
        Console.WriteLine("Error: File is missing");
        return BadRequest(new { error = "File is required." });
    }

    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
    if (!Directory.Exists(uploadsFolder))
        Directory.CreateDirectory(uploadsFolder);

    var filePath = Path.Combine(uploadsFolder, file.FileName);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await file.CopyToAsync(stream);
    }

    var document = new Document
    {
        Title = title,
        FilePath = filePath,
        VerificationCode = Guid.NewGuid().ToString().Substring(0, 8),
        Status = "Pending",
        CreatedAt = DateTime.UtcNow
    };

    _context.Documents.Add(document);
    await _context.SaveChangesAsync();

    return Ok(new { message = "Document uploaded successfully!", document });
}

}
}
