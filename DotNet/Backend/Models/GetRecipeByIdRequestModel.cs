using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class GetRecipeByIdRequestModel
    {
        [Required(ErrorMessage = "The Recipe ID is required!")]
        public int Id { get; set; }
    }
}
