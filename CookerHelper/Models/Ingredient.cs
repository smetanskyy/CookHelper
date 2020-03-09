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
        public string Name { get; set; }
        public int KindOfIngredientId { get; set; }
        public virtual KindOfIngredient KindOfIngredient { get; set; }
        public int ProteinPer100g { get; set; }
        public int FatPer100g { get; set; }
        public int CarbohydratesPer100g { get; set; }
        public int CaloriesPer100g { get; set; }

    }
}
