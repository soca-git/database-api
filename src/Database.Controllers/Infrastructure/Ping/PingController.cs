using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Database.Controllers.Infrastructure.Ping
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Route("api/database/ping")]
    public class PingController : ControllerBase
    {
        /// <summary>
        /// Returns a friendly message if the server is accessible.
        /// </summary>
        public async Task<string> Get()
        {
            return await Task.FromResult("Hello from Database-API!");
        }
    }
}
