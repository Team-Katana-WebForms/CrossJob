namespace CrossJob.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Constants;

    public class Advertisement
    {
        private ICollection<Freelancer> freelancers;

        public Advertisement()
        {
            this.freelancers = new HashSet<Freelancer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(AdvertisementConstants.MinTitleLength)]
        [MaxLength(AdvertisementConstants.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(AdvertisementConstants.MinDescriptionLength)]
        [MaxLength(AdvertisementConstants.MaxDescriptionLength)]
        public string Description { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public DateTime DateOfExpiration { get; set; }

        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Freelancer> Freelancers
        {
            get { return this.freelancers; }
            set { this.freelancers = value; }
        }
    }
}
