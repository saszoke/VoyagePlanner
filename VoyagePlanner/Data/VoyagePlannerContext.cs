using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoyagePlanner.Models;

namespace VoyagePlanner.Data
{
    public class VoyagePlannerContext : DbContext
    {
        public VoyagePlannerContext (DbContextOptions<VoyagePlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Voyage> Voyages { get; set; } = default!;
        public DbSet<VoyagePlanner.Models.Person> Persons { get; set; } = default!;

        public DbSet<VoyagePlanner.Models.Destination> Destinations { get; set; } = default!;
        public DbSet<VoyagePlanner.Models.Extra> Extras { get; set; } = default!;
        public DbSet<VoyagePlanner.Models.ExtraDetail> ExtraDetail { get; set; } = default!;

        public DbSet<VoyagePlanner.Models.TravelType> TravelTypes { get; set; } = default!;
        public DbSet<VoyagePlanner.Models.Country> Countries { get; set; } = default!;
        public DbSet<VoyagePlanner.Models.Allowance> Allowances { get; set; } = default!;



    }
}
