namespace CrossJob.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Employee : User
    {
        private ICollection<Advertisement> advertisements;

        public Employee()
        {
            this.advertisements = new HashSet<Advertisement>();
        }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Advertisement> Advertisements
        {
            get { return this.advertisements; }
            set { this.advertisements = value; }
        }
    }
}
