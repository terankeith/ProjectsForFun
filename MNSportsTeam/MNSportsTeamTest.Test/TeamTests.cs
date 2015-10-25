using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;
using MNSportsTeam.Operations;

namespace MNSportsTeamTest.Test
{
    [TestFixture]
    public class TeamTests
    {
        [TestCase(1, "Minnesota Vikings")]
        public void TestGetByTeamID(int Id, string expectedTeamName)
        {
            TeamOps ops = new TeamOps();
            var team = ops.GetAllTeams().SingleOrDefault(n => n.TeamId == Id);
            string teamName = team.Name;

            Assert.AreEqual(teamName, expectedTeamName);
        }

        //[TestCase("Minnesota Vikings", true)] //How to test if a team has been deleted?
        //public void TestDeleteTeam(string teamName, bool expected)
        //{
        //    TeamOps ops = new TeamOps();
        //    using (MNSportsTeamContext context = new MNSportsTeamContext())
        //    {
        //        var team = ops.GetAllTeams().SingleOrDefault(n => n.Name == teamName);
        //        context.Teams.Remove(team);
        //    }

            
        //}
    }
}
