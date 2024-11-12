namespace KanbanBlazorApp.Entities
{
    public class Reading
    {
        public int ReadingId { get; set; } // Klucz główny
        public int ScaleId { get; set; } // Klucz obcy do Scales
        public Scale Scale { get; set; } // Nawigacja do Scale

        public decimal ReadingWeight { get; set; }
        public DateTime ReadingDate { get; set; }
    }
}
