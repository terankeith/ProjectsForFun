using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSportsTeam.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Mascot { get; set; }
        public string Coach { get; set; }
        public string Owner { get; set; }
        public decimal AvgSalary { get; set; }
        public bool Active { get; set; }
        public int Convictions { get; set; }

        public int? VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        public int? YearId { get; set; }
        public virtual Year Year { get; set; }

        public virtual List<Championship> Championships { get; set; }
    }
}
