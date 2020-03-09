using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblKindOfKitchens")]
    public class KindOfKitchen
    {
        [Key]
        public int KindOfKitchenId { get; set; }
        [Required, StringLength(200)]
        public string KindOfKitchenNameENG { get; set; }
        [Required, StringLength(200)]
        public string KindOfKitchenNameUA { get; set; }
        [StringLength(200)]
        public string Image { get; set; }

    }
}
