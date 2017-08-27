using System.Data.Entity;


namespace MvcGET.Models
{
    public class SkolaDBContext : DbContext
    {
        public SkolaDBContext()
        {
        //    Database.SetInitializer<SkolaDBContext>(new DropCreateDatabaseAlways<SkolaDBContext>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Ispit> Ispits { get; set; }

        public DbSet<Predmet> Predmets { get; set; }

        public DbSet<StudentIspit> StudentIspits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}