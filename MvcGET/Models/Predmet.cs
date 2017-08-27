using System.ComponentModel.DataAnnotations;

namespace MvcGET.Models
{
    /// <summary>
    /// Subject entity
    /// </summary>
    [MetadataType(typeof(PredmetMetaData))]
    public class Predmet
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int BI { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string Tema { get; set; }
    }
}