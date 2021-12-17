using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UpdateRecipeRequestModel
    {
        [Required(ErrorMessage = "The Recipe ID is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Recipe Name field must be required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Descreption field must be required!")]
        public string Description { get; set; }

        public List<UpdateRecipeIngredientListItemRequestModel> Ingredients { get; set; }

        public UpdateRecipeRequestModel()
        {
            Ingredients = new List<UpdateRecipeIngredientListItemRequestModel>();
        }
    }
}
