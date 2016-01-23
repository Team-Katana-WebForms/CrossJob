namespace CrossJob.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Tag
    {
        private ICollection<Category> categories;

        public Tag()
        {
            this.categories = new HashSet<Category>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(TagConstants.MinNameLength)]
        [MaxLength(TagConstants.MaxNameLength)]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
