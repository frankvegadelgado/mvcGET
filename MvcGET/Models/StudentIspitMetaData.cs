using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{
    /// <summary>
    /// StudentIspi tMetaData
    /// </summary>
    [Table("StudentIspits")]
    public class StudentIspitMetaData
    {
        /// <summary>
        /// Not a generated column,
        /// Foreign key to Student
        /// </summary>
        [Key, Column("Student_BI", Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Student")]
        public int StudentId { get; set; }

        /// <summary>
        /// Not a generated column,
        /// Foreign key to Ispit
        /// </summary>
        [Key, Column("Ispit_BI", Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Ispit")]
        public int IspitId { get; set; }

        /// <summary>
        /// Entity relation
        /// </summary>
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        /// <summary>
        /// Entity relation
        /// </summary>
        [ForeignKey("IspitId")]
        public virtual Ispit Ispit { get; set; }
    }
}