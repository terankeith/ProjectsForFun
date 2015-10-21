using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;

namespace MNSportsTeam.Repositories
{
    public interface ITeamRepository
    {
        Team CreateTeam();
        void AddTeam(Team teamToBeAdded);
        List<Team> GetAllTeams();
        Team GetTeamByID(int Id);
        void DeleteTeamByName(string teamName);
        void DisplayTeams();       
    }
}
