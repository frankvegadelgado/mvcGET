using System.ComponentModel.DataAnnotations;

namespace MvcGET.Models
{
    /// <summary>
    /// Many-to-many relationship
    /// </summary>
    [MetadataType(typeof(StudentIspitMetaData))]
    public class StudentIspit
    {
        /// <summary>
        /// Student id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Exam id
        /// </summary>
        public int IspitId { get; set; }

        /// <summary>
        /// Student
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// Exam
        /// </summary>
        public virtual Ispit Ispit { get; set; }
    }
}