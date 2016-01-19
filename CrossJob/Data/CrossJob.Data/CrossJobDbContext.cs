namespace CrossJob.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class CrossJobDbContext : IdentityDbContext<User>, ICrossJobDbContext
    {
        public CrossJobDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CrossJobDbContext Create()
        {
            return new CrossJobDbContext();
        }
    }
}
