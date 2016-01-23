namespace CrossJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        public string FreelancerID { get; set; }

        public virtual Freelancer Freelancer { get; set; }

        public string EmployerID { get; set; }

        public virtual Employer Employeer { get; set; }
    }
}
