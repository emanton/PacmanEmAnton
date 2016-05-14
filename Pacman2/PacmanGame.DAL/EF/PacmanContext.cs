using System.Data.Entity;
using PacmanGame.DAL.Entities;

namespace PacmanGame.DAL.EF
{
    public class PacmanGameContext : DbContext
    {
        static PacmanGameContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public PacmanGameContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<PacmanGameContext>
    {
        protected override void Seed(PacmanGameContext db)
        {
            db.Users.Add(new User {Name = "example 1", Score = 55});
            db.SaveChanges();
        }
    }
}