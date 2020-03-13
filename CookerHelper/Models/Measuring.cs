using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblMeasuring")]
    public class Measuring
    {
        [Key]
        public int MeasuringId { get; set; }
        [Required, StringLength(100)]
        public string MeasuringNameUA { get; set; }
        [Required, StringLength(100)]
        public string MeasuringNameENG { get; set; }
    }
}
