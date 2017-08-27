using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace MvcGET.Models
{

    public interface ISkolaDBContext: IDisposable
    {
        DbSet<Student> Students { get; set; }

        DbSet<Ispit> Ispits { get; set; }

        DbSet<Predmet> Predmets { get; set; }

        DbSet<StudentIspit> StudentIspits { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }

    public class SkolaDBContext : DbContext, ISkolaDBContext
    {
        public SkolaDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SkolaDBContext>());
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Ispit> Ispits { get; set; }

        public virtual DbSet<Predmet> Predmets { get; set; }

        public virtual DbSet<StudentIspit> StudentIspits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}