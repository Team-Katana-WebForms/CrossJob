namespace CrossJob.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Project
    {
        private ICollection<Comment> comments;

        public Project()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

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

        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
