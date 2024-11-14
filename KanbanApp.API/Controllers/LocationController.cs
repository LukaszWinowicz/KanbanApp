using KanbanApp.API.Database;
using KanbanApp.API.Services;
using KanbanBlazorApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _service;
        private readonly KanbanDbContext _context;

        public LocationController(LocationService service, KanbanDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<LocationDto>> GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);

        }

        [HttpGet("rack/{rackName}")]
        public async Task<IActionResult> GetLocationsByRack(string rackName)
        {
            var results = await _context.Locations
                .Where(l => l.RackName == rackName) // Filtrowanie po Rack
                .Include(l => l.Item)               // Dołączamy Item, aby uzyskać Factor10Pcs
                .Include(l => l.Scale)              // Dołączamy Scale, aby uzyskać dane z Readings
                .ThenInclude(s => s.Readings)       // Dołączamy Readings, aby uzyskać ReadingWeight
                .Select(l => new
                {
                    RackShelf = $"{l.RackName}{l.Shelf}",       // Rack + Shelf
                    ShelfSpace = l.ShelfSpace,
                    Item = l.ItemNumber,
                    Qty = l.Scale != null
                            ? l.Scale.Readings
                            .Where(r => r.ScaleId == l.ScaleId)  // Readings.ScaleId = Location.ScaleId
                            .OrderByDescending(r => r.ReadingDate)
                            .Select(r => Math.Round((r.ReadingWeight * 10 ) / (l.Item != null && l.Item.Factor10Pcs > 0 ? l.Item.Factor10Pcs : 1), 2))
                            .FirstOrDefault() : (decimal?)null
                })
                .ToListAsync();

            return Ok(results);
        }


    }
}
