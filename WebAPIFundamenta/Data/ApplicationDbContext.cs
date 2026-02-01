

using System.Data.Entity;
using WebAPIFundamenta.Models;

namespace VideoRentalApplication.Models
{
    public class ApplicationDbContext :   DbContext
    {
        public ApplicationDbContext()
            : base("DbConnection")
        {
        }

        public DbSet<Students> Students{ get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}