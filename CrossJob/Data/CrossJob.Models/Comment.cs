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

        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
