using Microsoft.AspNetCore.Mvc;
using TrixCompareDb.Data;

namespace TrixCompareDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabasesController : ControllerBase
    {
        private readonly TableRepository _repo;
        public DatabasesController(TableRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var keys = _repo.GetDatabaseKeys();
            return Ok(keys);
        }
    }
}
