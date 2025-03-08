using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SDDV5.Controllers
{
    [Route("api/verify")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public VerificationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyDocument(int documentId, string verifiedBy)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            string query = "INSERT INTO VerificationLogs (DocumentId, VerifiedBy, Timestamp, Status) VALUES (@DocId, @Verifier, GETDATE(), 'Verified')";
            await connection.ExecuteAsync(query, new { DocId = documentId, Verifier = verifiedBy });

            return Ok("Document Verified Successfully");
        }
    }
}
