using System.ComponentModel.DataAnnotations;

namespace MarketProspection.Models
{
    public class UpworkSuivi
    {
        public int Id { get; set; }

        [Required]
        public DateTime ProposalDate { get; set; } = DateTime.Now;
        [Required]
        public string JobTitle { get; set; }
        public int RequiredConnects { get; set; }
        public int Bid { get; set; }

        public int ProjectLengthId { get; set; }

        public ProjectLength ProjectLength { get; set; }

        public int PricingTypeId { get; set; }

        public PricingType PricingType { get; set; }
        [Required]
        public string ClientPricing { get; set; }
        public int Pricing { get; set; }

        public int SubmittingProfileId { get; set; }

        public SubmittingProfile SubmittingProfile { get; set; }

        [Required]
        public string JobLink { get; set; }

        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public bool Viewed { get; set; } = false;

        public DateTime? ViewDate { get; set; } = null;

        public bool Response { get; set; }
        public DateTime? ResponseDate { get; set; } = null;

        public bool Interview { get; set; }
        public DateTime? InterviewDate { get; set; } = null;

        public bool Hired { get; set; }
        public DateTime? HireDate { get; set; } = null;
    }
}
