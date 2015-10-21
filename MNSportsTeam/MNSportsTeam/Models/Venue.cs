using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSportsTeam.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string Building { get; set; }
        public string City { get; set; }

        public virtual List<Team> Teams { get; set; }
    }
}
