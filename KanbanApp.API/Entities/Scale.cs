namespace KanbanBlazorApp.Entities
{
    public class Scale
    {
        public int ScaleId { get; set; }
        public decimal CalibrationFactor { get; set; }
        public decimal InitialWeight{ get; set; }

        // Nawigacja do Location (relacja jeden-do-jeden)
        public Location Location { get; set; }

        // Nawigacja do Readings (Relacja jeden-do-wielu)
        public ICollection<Reading> Readings { get; set; }

    }
}
