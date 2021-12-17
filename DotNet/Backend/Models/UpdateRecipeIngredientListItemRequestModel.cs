using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UpdateRecipeIngredientListItemRequestModel
    {
        [Required(ErrorMessage = "The Ingredient Name field must be required!")]
        public string Name { get; set; }
    }
}
