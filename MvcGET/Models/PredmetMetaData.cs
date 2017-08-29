using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{
    /// <summary>
    /// Ispit MetaData
    /// </summary>
    [Table("Predmet")]
    public class PredmetMetaData
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int BI { get; set; }

        /// <summary>
        /// Required field
        /// </summary>
        [Required]
        public string Tema { get; set; }
    }
}