using KanbanBlazorApp.DTOs;
using KanbanBlazorApp.Entities;

namespace KanbanApp.API.Mapper
{
    public class MapperLocation
    {
        public LocationDto MapToDto(Location location)
        {
            if (location == null) return null;

            return new LocationDto
            {
                LocationName = location.LocationName,
                ItemNumber = location.ItemNumber,
                BoxSize = location.BoxSize.ToString(),
                BoxType = location.BoxType.ToString(),
            };
        }
    }
}
