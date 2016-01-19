namespace CrossJob.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MinLength(CommentConstants.MinContentLength)]
        [MaxLength(CommentConstants.MaxContentLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual Freelancer User { get; set; }

        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
