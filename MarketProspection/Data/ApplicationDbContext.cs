using MarketProspection.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketProspection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectLength> ProjectLengths { get; set; }
        public DbSet<PricingType> PricingTypes { get; set; }
        public DbSet<SubmittingProfile> SubmittingProfiles { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public DbSet<UpworkSuivi> UpworkSuivis { get; set; }

    }
}