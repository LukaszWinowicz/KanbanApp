namespace KanbanBlazorApp.Entities
{
    public class Reading
    {
        public int ReadingId { get; set; } // Klucz główny
        public int LocationId { get; set; } // Klucz obcy do Location
        public Location Location { get; set; } // Nawigacja do Location

        public decimal ReadingWeight { get; set; }
        public DateTime ReadingDate { get; set; }
    }
}
