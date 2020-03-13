using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblIngredients")]
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required, StringLength(150)]
        public string NameUA { get; set; }
        public string NameENG { get; set; }
        public int KindOfIngredientId { get; set; }
        public virtual KindOfIngredient KindOfIngredient { get; set; }
        public double ProteinPer100g { get; set; }
        public double FatPer100g { get; set; }
        public double CarbohydratesPer100g { get; set; }
        public int CaloriesPer100g { get; set; }
        public double Worth1kg { get; set; }
        public string Image { get; set; }

    }
}
