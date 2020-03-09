using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblKindOfDishes")]
    public class KindOfDish
    {
        [Key]
        public int KindOfDishId { get; set; }
        [Required, StringLength(150)]
        public string KindOfDishNameUA { get; set; }
        [Required, StringLength(150)]
        public string KindOfDishNameENG { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
    }
}
