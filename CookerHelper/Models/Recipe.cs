using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.Models
{
    [Table("tblRecipes")]
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Directions { get; set; }
        public int PrepareTime { get; set; }
        public int CookTime { get; set; }
        public float Rate { get; set; }
        public int Vote { get; set; }
    }
}
