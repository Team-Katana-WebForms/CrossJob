namespace CrossJob.Models
{
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class Freelancer : User
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public decimal RatePerHour { get; set; }

        public double AverageRating
        {
            get
            {
                if (this.ratings.Count != 0)
                {
                   return this.ratings.Average(r => r.Value);
                }
                else
                {
                    return 0;
                }
            }
        }

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
