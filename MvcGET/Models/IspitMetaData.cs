using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{
    /// <summary>
    /// Ispit MetaData
    /// </summary>
    [Table("Ispit")]
    public partial class IspitMetaData
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int BI { get; set; }

        /// <summary>
        /// Not a mapped column to database
        /// </summary>
        [NotMapped, Display(Name = "Ispit Ime"), Column(Order = 0)]
        public string Ime { get; }

        /// <summary>
        /// Foreign key to Predmet
        /// </summary>
        [Required, Column("Predmet_BI")]
        public int PredmetId { get; set; }

        /// <summary>
        /// Entity relation
        /// </summary>
        [ForeignKey("PredmetId")]
        public virtual Predmet Predmet { get; set; }

        /// <summary>
        /// Grade range between 5 and 10
        /// </summary>
        [Required]
        [Range(5, 10)]
        public int Ocena { get; set; }

    }
}