using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{

    [Table("Ispit")]
    public partial class IspitMetaData
    {
        [Key]
        public int BI { get; set; }

        [NotMapped, Display(Name = "Ispit Ime"), Column(Order = 0)]
        public string Ime { get; }

        [Required, Column("Predmet_BI")]
        public int PredmetId { get; set; }

        [ForeignKey("PredmetId")]
        public virtual Predmet Predmet { get; set; }

        [Required]
        [Range(5, 10)]
        public int Ocena { get; set; }

    }
}