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

            Console.WriteLine("1. Display a Team");
            Console.WriteLine("\n2. Add a Team");
            Console.WriteLine("\n3. Add a Year");
            Console.WriteLine("\n4. Add a Venue");
            Console.WriteLine("\n5. Add a Championship");
            Console.WriteLine("\n6. Delete a Team");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    TeamOps.DisplayTeams();
                    Console.WriteLine("Type the name of the team you would like to see more information about.");
                    string input = Console.ReadLine();
                    Team displayTeam = TeamOps.GetTeamByName(input);
                    Console.Clear();
                    Console.WriteLine("Team Name: {0}", displayTeam.Name);
                    Console.WriteLine("Sport: {0}", displayTeam.Sport);
                    Console.WriteLine("Mascot: {0}", displayTeam.Mascot);
                    Console.WriteLine("Coach: {0}", displayTeam.Coach);
                    Console.WriteLine("Owner: {0}", displayTeam.Owner);
                    Console.WriteLine("Average Salary: {0}", displayTeam.AvgSalary);
                    Console.WriteLine("Activity Status: {0}", displayTeam.Active);
                    Console.WriteLine("Number of Convictions: {0}", displayTeam.Convictions);
                    Console.ReadLine();
                    break;
                case "2":
                    Team newTeam = TeamOps.CreateTeam();
                    TeamOps.AddTeam(newTeam);                    
                    break;
                case "3":
                    Year newYear = YearOps.CreateYear();
                    YearOps.AddYear(newYear);                    
                    break;
                case "4":
                    Venue newVenue = VenueOps.CreateVenue();
                    VenueOps.AddVenue(newVenue);                    
                    break;
                case "5":
                    Championship newChamp = ChampOps.CreateChamp();
                    ChampOps.AddChamp(newChamp);                    
                    break;
                case "6":
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
