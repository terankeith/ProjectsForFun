using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;

namespace MNSportsTeam.Operations
{
    public class VenueOps
    {
        public Venue CreateVenue()
        {
            Console.Clear();
            Console.Write("Building: ");
            string building = Console.ReadLine();
            Console.Write("\nCity: ");
            string city = Console.ReadLine();

            Venue newVenue = new Venue()
            {
                Building = building,
                City = city
            };
            return newVenue;
        }

        public void AddVenue(Venue venueToBeAdded)
        {
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                context.Venues.Add(venueToBeAdded);
                context.SaveChanges();
            }
        }

        public List<Venue> GetAllVenues()
        {
            List<Venue> venueList = new List<Venue>();
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                foreach(var venue in context.Venues)
                {
                    Venue newVenue = new Venue();
                    newVenue.VenueId = venue.VenueId;
                    newVenue.Building = venue.Building;
                    newVenue.City = venue.City;
                    venueList.Add(newVenue);
                }
            }
            return venueList;
        }

        public void DisplayVenues()
        {
            var venueList = GetAllVenues();

            foreach (var venue in venueList)
            {
                Console.WriteLine("{0}: {1}", venue.VenueId, venue.Building);
            }
                
        }
    }
}
