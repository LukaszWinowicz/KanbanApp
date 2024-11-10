using KanbanApp.API.Entities;

namespace KanbanBlazorApp.Entities
{
    public class Location
    {
        public int LocationId { get; set; } // Klucz główny
        public string RackName { get; set; } // Klucz obcy do Rack
        
        public string Shelf {  get; set; } // wartości od "01" do "07"
        public string ShelfSpace { get; set; } // wartości od "01" do "13"
        public BoxSize BoxSize { get; set; } // enum
        public BoxType BoxType { get; set; } // enum
        public int ScaleId { get; set; } // Klucz obcy do Scale
        public string ItemNumber { get; set; } // Klucz obcy do Item
        public string LocationName { get; set; } // Kolumna w bazie danych

        // Właściwości nawigacyjne
        public Rack Rack { get; set; }
        public Scale Scale { get; set; }
        public Item Item { get; set; }
        public ICollection<Reading> Readings { get; set; }

    }

    public enum BoxSize
    {
        Small = 1,  // Oznacza 1 miejsce
        Medium = 2, // Oznacza 1,5 miejsca
        Large = 3   // Oznacza 2 miejsca
    }
    public enum BoxType
    {
        Planned,
        Bufab,
        Wurth
    }
}
