using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using TrixCompareDb.Data;
using TrixCompareDb.Models;
using TrixCompareDb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrixCompareDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompareController : ControllerBase
    {
        private readonly TableRepository _repo;
        private readonly CompareTables _comparer;

        public CompareController(TableRepository repo, CompareTables comparer)
        {
            _repo = repo;
            _comparer = comparer;
        }

        [HttpPost]
        public async Task<IActionResult> Compare([FromBody] CompareRequest request)
        {
            // Compare the same table name between two different connection strings / databases
            var source = await _repo.GetTable(request.DatabaseSource, request.TableName);
            var target = await _repo.GetTable(request.DatabaseTarget, request.TableName);

            var result = _comparer.Compare(source, target);

            return Ok(result);
        }
    }
}
