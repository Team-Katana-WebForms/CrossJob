namespace CrossJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employer : User
    {
        [Required]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string WebSite { get; set; }
    }
}
