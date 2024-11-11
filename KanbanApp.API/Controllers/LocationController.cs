using KanbanApp.API.Database;
using KanbanApp.API.Services;
using KanbanBlazorApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _service;

        public LocationController(LocationService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<LocationDto>> GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);

        }


    }
}
