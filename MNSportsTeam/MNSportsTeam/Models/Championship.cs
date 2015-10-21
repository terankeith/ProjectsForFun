using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSportsTeam.Models
{
    public class Championship
    {
        public int ChampionshipId { get; set; }
        public string ChampYear { get; set; }
        public string Title { get; set; }
        
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
