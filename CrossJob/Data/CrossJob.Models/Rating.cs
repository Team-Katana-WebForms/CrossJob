namespace CrossJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(1,5)]
        public int Value { get; set; }
    }
}
