using KanbanApp.API.Database;
using KanbanBlazorApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaleController : ControllerBase
    {

        private readonly KanbanDbContext _context;

        public ScaleController(KanbanDbContext context) 
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Scale>> GetAll()
        {
            var result = _context.Scales.ToList();
            return result;

        }
    }
}
