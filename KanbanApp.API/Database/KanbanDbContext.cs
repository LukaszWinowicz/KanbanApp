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
                entity.Property(e => e.LocationId).IsRequired();
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
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationId);
                entity.Property(e => e.RackName)
                      .IsRequired();
                entity.Property(e => e.Shelf)
                      .IsRequired()
                      .HasMaxLength(2);
                entity.Property(e => e.ShelfSpace)
                      .IsRequired()
                      .HasMaxLength(2);
                entity.Property(e => e.ItemNumber).IsRequired();
                entity.HasIndex(e => e.LocationName)
                      .IsUnique(); // LocationName musi być unikalne

                // Właściwość nawigazyjna do Item (klucz obcy)
                entity.HasOne(e => e.Item)
                      .WithMany(i => i.Locations) // Jeden Item do wielu Location
                      .HasForeignKey(e => e.ItemNumber) // Klucz obcy w Location
                      .OnDelete(DeleteBehavior.Cascade); // Usunięcie Item usuwa powiązane Location [??]

                // Relacja z Rack
                entity.HasOne(l => l.Rack) // Nawigacja do Rack
                      .WithMany(r => r.Locations) // Relacja odwrotna
                      .HasForeignKey(l => l.RackName) // Klucz obcy w Location
                      .OnDelete(DeleteBehavior.Restrict); // Usunięcie Rack nie usuwa Location

                // Relacja jeden-do-jeden z Scale
                entity.HasOne(l => l.Scale) // Lokalizacja ma jedną Skalę
                      .WithOne(s => s.Location) // Skala ma jedną Lokalizację
                      .HasForeignKey<Location>(l => l.ScaleId) // Klucz obcy w Location
                      .OnDelete(DeleteBehavior.Restrict); // Usunięcie Scale nie usuwa Location

            });

            // Konfiguracja encji Rack
            modelBuilder.Entity<Rack>(entity => 
            { 
                entity.HasKey(e => e.RackName);

                // Właściwość nawigazyjna do Location(klucz obcy)
                entity.HasMany(r => r.Locations) // Jeden Rack do wielu Location
                      .WithOne(l => l.Rack) // Jedno Location do jednego Rack
                      .HasForeignKey(l => l.RackName) // Klucz obcy w Location
                      .OnDelete(DeleteBehavior.Restrict); //Usunięcie Rack nie usuwa Location

            });

            // Konfiguracja encji Scale
            modelBuilder.Entity<Scale>(entity =>
            {
                entity.HasKey(e => e.ScaleId);
                entity.Property(e => e.CalibrationFactor)
                      .IsRequired()
                      .HasPrecision(10, 2); // Precyzja dla CalibrationFactor

                entity.Property(e => e.InitialWeight)
                      .IsRequired()
                      .HasPrecision(10, 2); // Precyzja dla InitialWeight

                // Relacja jeden-do-jeden z Location
                entity.HasOne(s => s.Location) // Skala ma jedną Lokalizację
                      .WithOne(l => l.Scale) // Lokalizacja ma jedną Skalę
                      .HasForeignKey<Location>(l => l.ScaleId) // Klucz obcy w Location
                      .OnDelete(DeleteBehavior.Restrict); // Usunięcie Scale nie usuwa Location
            });

        }

    }
}
