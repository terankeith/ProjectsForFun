using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSportsTeam.Models
{
    public class Year
    {
        public int YearId { get; set; }
        public string YearFounded { get; set; }
        public string YearDisbanded { get; set; }

        public virtual List<Team> Teams { get; set; }
    }
}
