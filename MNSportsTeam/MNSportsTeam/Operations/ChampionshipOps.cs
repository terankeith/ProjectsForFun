using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;

namespace MNSportsTeam.Operations
{
    public class ChampionshipOps
    {
        public Championship CreateChamp()
        {
            Console.Write("Championship Year: ");
            string champYear = Console.ReadLine();
            Console.Write("\nTitle: ");
            string title = Console.ReadLine();

            Championship newChamp = new Championship()
            {
                ChampYear = champYear,
                Title = title
            };

            return newChamp;
        }

        public void AddChamp(Championship champToBeAdded)
        {
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                context.Championships.Add(champToBeAdded);
                context.SaveChanges();
            }
        }
    }
}
