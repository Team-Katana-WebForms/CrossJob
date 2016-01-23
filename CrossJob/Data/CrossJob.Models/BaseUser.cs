namespace CrossJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseUser
    {
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public string UserID { get; set; }

        public virtual User User { get; set; }
    }
}
