using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{
    
    [Table("Predmet")]
    public class PredmetMetaData
    {
        [Key]
        public int BI { get; set; }

        [Required]
        public string Tema { get; set; }
    }
}