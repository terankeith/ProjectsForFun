using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;
using MNSportsTeam.Operations;

namespace MNSportsTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamOps TeamOps = new TeamOps();
            YearOps YearOps = new YearOps();
            VenueOps VenueOps = new VenueOps();
            ChampionshipOps ChampOps = new ChampionshipOps();

            Console.WriteLine("1. Add a Team");
            Console.WriteLine("\n2. Add a Year");
            Console.WriteLine("\n3. Add a Venue");
            Console.WriteLine("\n4. Add a Championship");
            Console.WriteLine("\n5. Delete a Team");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":                  
                    Team newTeam = TeamOps.CreateTeam();
                    TeamOps.AddTeam(newTeam);
                    break;
                case "2":                    
                    Year newYear = YearOps.CreateYear();
                    YearOps.AddYear(newYear);
                    break;
                case "3":                    
                    Venue newVenue = VenueOps.CreateVenue();
                    VenueOps.AddVenue(newVenue);
                    break;
                case "4":                    
                    Championship newChamp = ChampOps.CreateChamp();
                    ChampOps.AddChamp(newChamp);
                    break;
                case "5":
                    Console.Clear();
                    TeamOps.DisplayTeams();
                    Console.Write("\nEnter the name of the team you would like to delete: ");                   
                    string teamName = Console.ReadLine();
                    TeamOps.DeleteTeamByName(teamName);
                    break;
                default:
                    break;
            }
        }
    }
}
