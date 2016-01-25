namespace CrossJob.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MinLength(CommentConstants.MinContentLength)]
        [MaxLength(CommentConstants.MaxContentLength)]
        public string Content { get; set; }

        public string FreelancerId { get; set; }

        public virtual Freelancer Freelancer { get; set; }

        public string EmployerId { get; set; }

        public virtual Employer Employer { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }
    }
}
