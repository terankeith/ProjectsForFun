using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSportsTeam.Models
{
    public class MNSportsTeamContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Year> Years { get; set; }
    }
}
