using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        public List<GetRecipeByIdResponseModel> receipes = new List<GetRecipeByIdResponseModel>
        {
            new GetRecipeByIdResponseModel
            {
                Id = 1,
                Name = "AppleJuice",
                Description = "Yummy Apple Juice",
                Ingredients = new List<GetRecipeByIdIngredientListItemResponseModel>
                {
                    new GetRecipeByIdIngredientListItemResponseModel { Name = "Apple" },
                    new GetRecipeByIdIngredientListItemResponseModel { Name = "Sugar" },
                    new GetRecipeByIdIngredientListItemResponseModel { Name = "Milk" }
                }
            },
            new GetRecipeByIdResponseModel
            {
                Id = 2,
                Name = "BreadOmlette",
                Description = "Spicy Bread Omlette",
                Ingredients = new List<GetRecipeByIdIngredientListItemResponseModel>
                {
                    new GetRecipeByIdIngredientListItemResponseModel { Name = "Bread" },
                    new GetRecipeByIdIngredientListItemResponseModel { Name = "Chilly" },
                    new GetRecipeByIdIngredientListItemResponseModel { Name = "Salt" }
                }
            }
        };

        [HttpGet("GetAll")]
        public ActionResult<GetAllRecipeResponseModel> GetAllRecipe()
        {
            var result = new GetAllRecipeResponseModel
            {
                Recipes = new List<GetAllRecipeListItemResponseModel> 
                {
                    new GetAllRecipeListItemResponseModel { Id = 1, Name = "AppleJuice", Description = "Yummy Apple Juice",  },
                    new GetAllRecipeListItemResponseModel { Id = 2, Name = "BreadOmlette", Description = "Spicy Bread Omlette" }
                }
            };

            return result;
        }

        [HttpPost("GetById")]
        public ActionResult<GetRecipeByIdResponseModel> GetRecipeById([FromBody] GetRecipeByIdRequestModel requestModel)
        {
            var recipe = receipes.Where(x => x.Id == requestModel.Id).FirstOrDefault();
            return Ok(recipe);
        }

        [HttpPut("Update")]
        public IActionResult UpdateRecipe([FromBody] UpdateRecipeRequestModel model)
        {
            foreach (var receipe in receipes.Where(w => w.Id == model.Id))
            {
                receipe.Name = model.Name;
                receipe.Description = model.Description;
                receipe.Ingredients.Clear();
                model.Ingredients.ForEach(x =>
                {
                    receipe.Ingredients.Add(new GetRecipeByIdIngredientListItemResponseModel { Name = x.Name });
                });
            }

            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult DeleteRecipe([FromBody] DeleteRecipeRequestModel requestModel)
        {
            var receipeToRemove = receipes.SingleOrDefault(r => r.Id == requestModel.Id);
            var recipe = receipes.Remove(receipeToRemove);
            return Ok(recipe);
        }
    }
}
