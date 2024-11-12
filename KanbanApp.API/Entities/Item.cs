namespace KanbanBlazorApp.Entities
{
    public class Item
    {
        public string ItemNumber { get; set; } // Klucz główny
        public string Description { get; set; }
        public string Supplier { get; set; }
        public decimal Factor10Pcs { get; set; }

    // Właściwość nawigacyjna do lokalizacji
    public ICollection<Location> Locations { get; set; }
    }
}
