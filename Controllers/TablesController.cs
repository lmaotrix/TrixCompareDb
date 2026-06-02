using Microsoft.AspNetCore.Mvc;
using TrixCompareDb.Data;
using System.Threading.Tasks;

namespace TrixCompareDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly TableRepository _repo;
        public TablesController(TableRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string database)
        {
            if (string.IsNullOrEmpty(database))
                return BadRequest("Query parameter 'database' is required.");

            var tables = await _repo.GetTablesAsync(database);
            return Ok(tables);
        }
    }
}
