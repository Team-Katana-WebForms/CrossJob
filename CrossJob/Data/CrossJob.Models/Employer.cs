namespace CrossJob.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employer : User
    {
        private ICollection<Project> projects;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public Employer()
            :base()
        {
            this.projects = new HashSet<Project>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        [Required]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
