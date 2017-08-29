using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace MvcGET.Models
{
    /// <summary>
    /// Unit work interface
    /// </summary>
    public interface ISkolaDBContext: IDisposable
    {
        /// <summary>
        /// Abstract DbSet Students
        /// </summary>
        DbSet<Student> Students { get; set; }

        /// <summary>
        /// Abstract DbSet Ispits
        /// </summary>
        DbSet<Ispit> Ispits { get; set; }

        /// <summary>
        /// Abstract DbSet Predmets
        /// </summary>
        DbSet<Predmet> Predmets { get; set; }

        /// <summary>
        /// Abstract DbSet StudentIspits
        /// </summary>
        DbSet<StudentIspit> StudentIspits { get; set; }

        /// <summary>
        /// DbContext method
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// DbContext async method
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// DbContext method
        /// </summary>
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }

    /// <summary>
    /// Unit work implementation
    /// </summary>
    public class SkolaDBContext : DbContext, ISkolaDBContext
    {
        /// <summary>
        /// Constructor,
        /// Recreate the database for each running
        /// </summary>
        public SkolaDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SkolaDBContext>());
        }

        /// <summary>
        /// DbSet Students
        /// </summary>
        public virtual DbSet<Student> Students { get; set; }

        /// <summary>
        /// DbSet Ispits
        /// </summary>
        public virtual DbSet<Ispit> Ispits { get; set; }

        /// <summary>
        /// DbSet Predmets
        /// </summary>
        public virtual DbSet<Predmet> Predmets { get; set; }

        /// <summary>
        /// DbSet StudentIspits
        /// </summary>
        public virtual DbSet<StudentIspit> StudentIspits { get; set; }

        /// <summary>
        /// Model creation builder
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}