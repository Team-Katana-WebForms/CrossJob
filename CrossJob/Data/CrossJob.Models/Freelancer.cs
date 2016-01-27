namespace CrossJob.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Collections.Generic;

    public class Freelancer : User
    {
        protected ICollection<Rating> ratings;

        public Freelancer()
        {
            this.ratings = new HashSet<Rating>();
        }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public decimal RatePerHour { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

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
    }
}

