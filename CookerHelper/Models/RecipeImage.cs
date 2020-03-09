using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblRecipeImages")]
    public class RecipeImage
    {
        [Key]
        public int RecipeImageId { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        [Required, StringLength(200)]
        public string Path { get; set; }
    }
}
