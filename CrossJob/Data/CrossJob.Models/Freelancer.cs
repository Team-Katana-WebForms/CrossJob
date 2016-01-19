namespace CrossJob.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Freelancer : User
    {
        private ICollection<Project> projects;
        private ICollection<Comment> comments;

        public Freelancer()
        {
            this.projects = new HashSet<Project>();
            this.comments = new HashSet<Comment>();
        }
        public string Country { get; set; } // from public API

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
