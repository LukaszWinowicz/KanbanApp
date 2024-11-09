namespace KanbanBlazorApp.Entities
{
    public class Scale
    {
        public int ScaleId { get; set; }
        public float CalibrationFactor { get; set; }
        public float InitialWeight{ get; set; }

        // Nawigacja do Location (relacja jeden-do-jeden)
        public Location Location { get; set; }
    }
}
