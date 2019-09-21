using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SeasonTracker.Models
{
    //The IdentityDbContext is the gateway to our database. It is part of Asp.net identity framework.
    //So when we execute enable-migration, Entity Framework (EF) looked at our IdentityDbContext and it discovered
    //Db sets in IdentityDbContext like user, role, etc.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Add DbSets
        //NOTE: Anytime this is modified must do migrations:
        // PM > add-migration name_of_migration -force
        // PM > update-database
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}