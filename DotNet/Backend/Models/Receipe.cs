using System;
using System.Collections.Generic;

namespace Backend
{

    public class GetAllRecipeResponseModel
    {
        public List<GetAllRecipeListItemResponseModel> Recipes { get; set; }
    }

    public class GetAllRecipeListItemResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
