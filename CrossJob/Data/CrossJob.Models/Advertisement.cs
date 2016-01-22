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

        public DateTime CreatedOn { get; set; }

        public string EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
    }
}
