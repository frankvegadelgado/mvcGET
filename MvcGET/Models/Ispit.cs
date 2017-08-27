using System.ComponentModel.DataAnnotations;

namespace MvcGET.Models
{
    /// <summary>
    /// Exam entity
    /// </summary>
    [MetadataType(typeof(IspitMetaData))]
    public class Ispit
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int BI { get; set; }

        /// <summary>
        /// Subject foreign key
        /// </summary>
        public int PredmetId { get; set; }

        /// <summary>
        /// Grade or Mark
        /// </summary>
        public int Ocena { get; set; }

        /// <summary>
        /// Subject child
        /// </summary>
        public virtual Predmet Predmet { get; set; }

    }
}