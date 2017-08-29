using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGET.Models
{
    /// <summary>
    /// Student MetaData
    /// </summary>
    [Table("Student")]
    public class StudentMetaData
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int BI { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [Required, Display(Name = "Student Ime")]
        public string Ime { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [Required]
        public string Prezime { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [Required]
        public string Adresa { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [Required]
        public string Grad { get; set; }
    }
}