using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VideoRentalApplication.Model;

namespace VideoRentalApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DbConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershiptType> MembershiptTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}