using KanbanApp.API.Entities;
using KanbanBlazorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp.API.Database
{
    public class KanbanDbContext : DbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Scale> Scales { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja encji Item
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemNumber);
                entity.Property(e => e.Description)
                      .IsRequired();
                entity.Property(e => e.Supplier)
                      .IsRequired();            
            });

            // Konfiguracja encji Reading
            modelBuilder.Entity<Reading>(entity =>
            {
                entity.HasKey(e => e.ReadingId);
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.ReadingWeight)
                      .IsRequired()
                      .HasPrecision(10, 2); // Precyzja dla wagi;
                entity.Property(e => e.ReadingDate)
                      .IsRequired();

                // Właściwość nawigazyjna do Location (klucz obcy)
                entity.HasOne(e => e.Location)
                      .WithMany(l => l.Readings) // Relacja odwrotna (jeden Location do wielu Reading)
                      .HasForeignKey(e => e.LocationId) // Klucz obcy w Reading
                      .OnDelete(DeleteBehavior.Cascade); // Usuwanie Location usuwa powiązane Readings
            });
               
            // Konfiguracja encji Location


        }

    }
}
