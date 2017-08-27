using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{
    [Table("StudentIspits")]
    public class StudentIspitMetaData
    {
        [Key, Column("Student_BI", Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        [Key, Column("Ispit_BI", Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IspitId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("IspitId")]
        public virtual Ispit Ispit { get; set; }
    }
}