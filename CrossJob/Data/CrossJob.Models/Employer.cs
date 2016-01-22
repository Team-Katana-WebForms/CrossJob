namespace CrossJob.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Employer : User
    {
        private ICollection<Advertisement> advertisements;
        private ICollection<Comment> comments;

        public Employer()
        {
            this.advertisements = new HashSet<Advertisement>();
            this.comments = new HashSet<Comment>();
        }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Advertisement> Advertisements
        {
            get { return this.advertisements; }
            set { this.advertisements = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
