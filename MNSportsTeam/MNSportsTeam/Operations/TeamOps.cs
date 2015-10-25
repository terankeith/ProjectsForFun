using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;
using MNSportsTeam.Repositories;

namespace MNSportsTeam.Operations
{
    public class TeamOps : ITeamRepository
    {
        public Team CreateTeam()
        {
            Team newTeam = new Team();
            int Id;
            bool isValid = false;
            Console.Clear();
            bool isActive = false;
            Console.Write("Enter the name of the team: ");
            string name = Console.ReadLine();
            Console.Write("\nSport: ");
            string sport = Console.ReadLine();
            Console.Write("\nMascot: ");
            string mascot = Console.ReadLine();
            Console.Write("\nCoach: ");
            string coach = Console.ReadLine();
            Console.Write("\nOwner: ");
            string owner = Console.ReadLine();
            Console.Write("\nAverage Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("\nIs the team still active(Y/N): ");
            string active = Console.ReadLine();
            if (active.ToUpper() == "Y")
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
            Console.Write("\nNumber of Convictions: ");
            int convictions = int.Parse(Console.ReadLine());

            VenueOps ops = new VenueOps();
            do {
                Console.Clear();
                ops.DisplayVenues();
                Console.Write("Enter the number that corresponds with the Venue Building.\nIf you do not know the building name press enter.\nIf you do know the name of the building, type 'Building'");
                string venue = Console.ReadLine();
                if (int.TryParse(venue, out Id))
                {
                    newTeam.VenueId = Id;
                    isValid = true;
                }
                else if (venue == "")
                {
                    newTeam.VenueId = null;
                    isValid = true;
                }
                else if (venue.ToUpper() == "BUILDING")
                {
                    Venue created = ops.CreateVenue();
                    ops.AddVenue(created);
                    isValid = false;
                }
                else
                {
                    isValid = false;
                }
            } while (!isValid);


            newTeam.Name = name;
            newTeam.Sport = sport;
            newTeam.Mascot = mascot;
            newTeam.Coach = coach;
            newTeam.Owner = owner;
            newTeam.AvgSalary = salary;
            newTeam.Active = isActive;
            newTeam.Convictions = convictions;
            
            return newTeam;
        }

        public void AddTeam(Team teamToBeAdded)
        {
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                context.Teams.Add(teamToBeAdded);
                context.SaveChanges();
            }
        }

        public List<Team> GetAllTeams()
        {
            List<Team> teamList = new List<Team>();
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                foreach (var team in context.Teams)
                {
                    Team newTeam = new Team();
                    newTeam.TeamId = team.TeamId;
                    newTeam.Name = team.Name;
                    newTeam.Sport = team.Sport;
                    newTeam.Mascot = team.Mascot;
                    newTeam.Coach = team.Coach;
                    newTeam.Owner = team.Owner;
                    newTeam.AvgSalary = team.AvgSalary;
                    newTeam.Active = team.Active;
                    newTeam.Convictions = team.Convictions;
                    newTeam.VenueId = team.VenueId;
                    newTeam.YearId = team.YearId;
                    newTeam.Championships = team.Championships;
                    teamList.Add(newTeam);
                }
            }
            return teamList;
        }

        public Team GetTeamByID(int Id)
        {
            return GetAllTeams().SingleOrDefault(n => n.TeamId == Id);
        }

        public void DeleteTeamByName(string teamName)
        { 
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                var teamToDelete = context.Teams.SingleOrDefault(n => n.Name == teamName);
                context.Teams.Remove(teamToDelete);
                context.SaveChanges();
            }
        }

        public void DisplayTeams()
        {

            List<Team> teamList = GetAllTeams();

            foreach (var team in teamList)
            {
                Console.WriteLine("{0}", team.Name);
            }

        }

        public Team GetTeamByName(string teamName)
        {
            return GetAllTeams().SingleOrDefault(n => n.Name == teamName);
        }
    }
}
