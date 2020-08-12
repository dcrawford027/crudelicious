using System;
using System.ComponentModel.DataAnnotations;

namespace crudelicious.Models
{
    public class Dish
    {
        [Key]

        [Required]
        public int DishId {get;set;}

        [Required(ErrorMessage = "Dish name is required.")]
        [MaxLength(45, ErrorMessage = "The dish's name can be no longer than 45 characters.")]
        [Display(Name = "Name of Dish")]
        public string Name {get;set;}

        [Required(ErrorMessage = "Chef's name is required.")]
        [MaxLength(45, ErrorMessage = "The dish's name can be no longer than 45 characters.")]
        [Display(Name = "Chef's Name")]
        public string Chef {get;set;}

        [Required]
        [Range(1, 6, ErrorMessage = "Tastiness rating must be from 1 to 5.")]
        public int Tastiness {get;set;}

        [Required]
        [Range(1, 5000, ErrorMessage = "Calories must be a number greater than 0.")]
        [Display(Name = "# of Calories")]
        public int Calories {get;set;}

        [Required(ErrorMessage = "A description is required.")]
        [MinLength(10, ErrorMessage = "The description must be at least 10 characters long.")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}