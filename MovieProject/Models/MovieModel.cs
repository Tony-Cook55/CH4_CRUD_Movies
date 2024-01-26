
// Used for [ValidateNever]
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

/* Allows for the [Required] and the [Range]*/
using System.ComponentModel.DataAnnotations;




namespace MovieProject.Models
{
    public class MovieModel
    {

        // Read-Only Property for the /slug in the Program.cs file
        public string Slug => Name?.Replace(" ", "-").ToLower() + "-" + Year?.ToString();



        // Primary Key
        public int MovieModelId { get; set; }



        [Required(ErrorMessage ="Please Enter a Name")]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please Enter a Year")]
        [Range(1900,2024, ErrorMessage ="Year Must be between 1900 and 2024")]
        public int? Year { get; set; }



        [Required(ErrorMessage = "Please Enter a Rating")]
        [Range(1, 5, ErrorMessage = "Rating Must be Between 1 and 5")]
        public int? Rating { get; set; }





        // Foreign Key Property  ~ Entity classes are easier to work with if you add Foreign Key properties that refer to the Primary Key in the related entity class
        [Required(ErrorMessage = "Please Enter a Genre")]
        public string GenreModelId { get; set; } = string.Empty;


        // NAVIGATION PROPERTY
        // Calls in our Genre Modal Class To be set to each Movie   LINKS BOTH CLASSES TOGETHER
        [ValidateNever]
        public GenreModel Genre { get; set; } = null!;






    }
}
