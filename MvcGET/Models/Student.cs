using System.ComponentModel.DataAnnotations;

namespace MvcGET.Models
{
    /// <summary>
    /// Student entity
    /// </summary>
    [MetadataType(typeof(StudentMetaData))]
    public class Student
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int BI { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string Grad { get; set; }


    }
}