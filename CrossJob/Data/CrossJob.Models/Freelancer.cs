namespace CrossJob.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

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

    }
}
