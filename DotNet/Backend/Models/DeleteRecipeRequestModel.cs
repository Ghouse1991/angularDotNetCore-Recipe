using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class DeleteRecipeRequestModel
    {
        [Required(ErrorMessage = "The ID of the Recipe to be deleted is Required!")]
        public int Id { get; set; }
    }
}
