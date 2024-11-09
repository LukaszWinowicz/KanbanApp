using KanbanBlazorApp.Entities;

namespace KanbanApp.API.Entities
{
    public class Rack
    {
        public string RackName { get; set; } // Klucz główny
        public ICollection<Location> Locations { get; set; } // Właściwość nawigacyjna do lokalizacji

    }
}
