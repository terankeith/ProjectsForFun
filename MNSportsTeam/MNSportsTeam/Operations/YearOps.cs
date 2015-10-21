using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNSportsTeam.Models;

namespace MNSportsTeam.Operations
{
    public class YearOps
    {
        public Year CreateYear()
        {
            Console.Write("Year Founded: ");
            string founded = Console.ReadLine();
            Console.Write("\nYear Disbanded: ");
            string disbanded = Console.ReadLine();
            if (disbanded == "")
            {
                disbanded = null;
            }

            Year newYear = new Year()
            {
                YearFounded = founded,
                YearDisbanded = disbanded
            };

            return newYear;
        }

        public void AddYear(Year yearToBeAdded)
        {
            using (MNSportsTeamContext context = new MNSportsTeamContext())
            {
                context.Years.Add(yearToBeAdded);
                context.SaveChanges();
            }
        }

    }
}
