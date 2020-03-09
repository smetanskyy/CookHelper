using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblKindOfIngredients")]
    public class KindOfIngredient
    {
        [Key]
        public int KindOfIngredientId { get; set; }
        [Required, StringLength(150)]
        public string KindOfIngredientNameUA { get; set; }
        [Required, StringLength(150)]
        public string KindOfIngredientNameENG { get; set; }
        public string Image { get; set; }
    }
}
