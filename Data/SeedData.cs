using Microsoft.EntityFrameworkCore;
using EventEase.Models;

namespace EventEase.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Venues.Any() || context.Events.Any())
                {
                    return; // DB has been seeded
                }

                context.Venues.AddRange(
                    new Venue
                    {
                        VenueName = "Grand Ballroom",
                        Location = "Downtown City Center",
                        Capacity = 500,
                        ImageUrl = "https://images.unsplash.com/photo-1519167758481-83f550bb49b3?w=500"
                    },
                    new Venue
                    {
                        VenueName = "Garden Pavilion",
                        Location = "Botanical Gardens",
                        Capacity = 200,
                        ImageUrl = "https://images.unsplash.com/photo-1464368081811-17597d3c6b52?w=500"
                    },
                    new Venue
                    {
                        VenueName = "Conference Hall A",
                        Location = "Business District",
                        Capacity = 150,
                        ImageUrl = "https://images.unsplash.com/photo-1431540010161-9539464107dc?w=500"
                    }
                );

                context.Events.AddRange(
                    new Event
                    {
                        EventName = "Corporate Gala 2026",
                        Description = "Annual company celebration",
                        EventDate = DateTime.Parse("2026-06-15"),
                        StartTime = TimeSpan.Parse("19:00"),
                        EndTime = TimeSpan.Parse("23:00"),
                        ImageUrl = "https://images.unsplash.com/photo-1511795409834-ef04bbd61622?w=500"
                    },
                    new Event
                    {
                        EventName = "Wedding Reception",
                        Description = "Smith-Johnson wedding",
                        EventDate = DateTime.Parse("2026-07-20"),
                        StartTime = TimeSpan.Parse("14:00"),
                        EndTime = TimeSpan.Parse("22:00"),
                        ImageUrl = "https://images.unsplash.com/photo-1519225421980-715cb0215aed?w=500"
                    },
                    new Event
                    {
                        EventName = "Tech Conference",
                        Description = "Annual technology summit",
                        EventDate = DateTime.Parse("2026-08-10"),
                        StartTime = TimeSpan.Parse("09:00"),
                        EndTime = TimeSpan.Parse("17:00"),
                        ImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=500"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}