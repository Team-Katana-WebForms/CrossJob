﻿namespace CrossJob.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Project
    {
        private ICollection<Freelancer> freelancers;

        public Project()
        {
            this.freelancers = new HashSet<Freelancer>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(ProjectConstants.MinTitleLength)]
        [MaxLength(ProjectConstants.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ProjectConstants.MinDescriptionLength)]
        [MaxLength(ProjectConstants.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? StartOn { get; set; }

        public DateTime? FinishOn { get; set; }

        public decimal Price { get; set; }

        public string EmployerID { get; set; }

        public virtual Employer Employer { get; set; }

        public ICollection<Freelancer> Freelancers
        {
            get { return this.freelancers; }
            set { this.freelancers = value; }
        }
    }
}
