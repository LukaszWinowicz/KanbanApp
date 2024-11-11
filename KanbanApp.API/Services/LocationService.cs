using KanbanApp.API.Database;
using KanbanApp.API.Mapper;
using KanbanBlazorApp.DTOs;

namespace KanbanApp.API.Services
{
    public class LocationService
    {
        private readonly KanbanDbContext _context;
        private readonly MapperLocation _mapper;

        public LocationService(KanbanDbContext context, MapperLocation mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<LocationDto> GetAll() 
        {
            // Pobranie wszystkich lokalizacji z db
            var locations = _context.Locations.ToList();

            // Mapowanie lokalizacji na DTO
            return locations.Select(location => _mapper.MapToDto(location)).ToList();
        }

    }
}
