using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class GetRecipeByIdResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<GetRecipeByIdIngredientListItemResponseModel> Ingredients { get; set; }
    }
}
