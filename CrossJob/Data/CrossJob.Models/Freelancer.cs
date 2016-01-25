namespace CrossJob.Models
{
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
    }
}
