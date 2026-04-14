using EventEase.Controllers;
using EventEase.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // These DbSet properties represent the actual tables in our database
        public DbSet<Venue> Venues { get; set; } // venue table
        public DbSet<Event> Events { get; set; } //events table
        public DbSet<Booking> Bookings { get; set; } //Bookings table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueId);
            // Each Booking belongs to one Venue. A Venue can have many Bookings.
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId);
        }
    }
}