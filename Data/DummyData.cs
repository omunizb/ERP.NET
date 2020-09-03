using ERPProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Adapted from https://github.com/medhatelmasry/HealthAPI/blob/master/HealthAPI/Data/DummyData.cs
namespace ERPProject.Data
{
    public class DummyData
    {
        /*
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AttendeeContext>();
                context.Database.EnsureCreated();

                // Look for any events
                if (context.Events != null && context.Events.Any())
                    return;

                var events = GetEvents().ToArray();
                context.Events.AddRange(events);
                context.SaveChanges();

                var users = GetUsers().ToArray();
                context.Users.AddRange(users);
                context.SaveChanges();

                var attendees = GetAttendees().ToArray();
                context.Attendees.AddRange(attendees);
                context.SaveChanges();
            }
        }

        public static List<Event> GetEvents()
        {
            List<Event> events = new List<Event>() {
                new Event {
                    Name="Student welcome",
                    Description = "like each Monday, we welcome new students at IT Academy.",
                    Date = new DateTime(2020, 7, 20, 9, 0, 0),
                    Online = true,
                    Type = "Special Event"
                },
                new Event {
                    Name="MySQL Masterclass",
                    Description = "A masterclass on MySQL by the Common Block itinerary instructor.",
                    Date = new DateTime(2020, 7, 23, 11, 30, 0),
                    Online = false, Capacity = 25,
                    Type = "Masterclass"
                },
                new Event {
                    Name="August holidays",
                    Description = "IT Academy closes until August 31st. In the attached file you can find the calendar for Septembler. Happy holidays!",
                    Date = new DateTime(2020, 7, 30, 13, 0, 0), File = "calendar-september.xlsx",
                    Online = false,
                    Type = "Holidays" }
            };
            return events;
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>() {
                new User {
                    Name = "Gerard",
                    Surname = "Ferrer",
                    Email = "gf@gmail.com",
                    Type = "student",
                    IdItinerary = 6
                },
                new User {
                    Name = "Oriol",
                    Surname = "Muñiz",
                    Email = "om@gmail.com",
                    Type = "student",
                    IdItinerary = 6
                },
                new User {
                    Name = "Francisco Javier",
                    Surname = "Rivas",
                    Email = "fjr@gmail.com",
                    Type = "student",
                    IdItinerary = 6
                }
            };
            return users;
        }

        public static List<Attendee> GetAttendees()
        {
            List<Attendee> attendees = new List<Attendee>() {
                new Attendee {
                    IdEvent = 1,
                    IdStudent = 1
                },
                new Attendee {
                    IdEvent = 2,
                    IdStudent = 2,
                    Accepted = true
                },
                new Attendee {
                    IdEvent = 2,
                    IdStudent = 3,
                    Accepted = true
                },
            };
            return attendees;
        }
        */
    }
}
