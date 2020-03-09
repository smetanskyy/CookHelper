using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblRecipeIngredients")]
    public class RecipeIngredients
    {
        [Key]
        public int RecipeIngredientId { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        [Required]
        public float Amount { get; set; }

        public int MeasuringId { get; set; }
        public virtual Measuring Measuring { get; set; }

    }
}
