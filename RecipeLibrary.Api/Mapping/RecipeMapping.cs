using RecipeLibrary.Api.Dtos;
using RecipeLibrary.Api.Entities;

namespace RecipeLibrary.Api.Mapping;

public static class RecipeMapping
{
    public static Recipe ToEntity(this CreateRecipeDto recipe)
    {
        return new Recipe()
        {
            Name = recipe.Name,
            CuisineId = recipe.CuisineId,
            CookTime = recipe.CookTime,
            Ingredients = recipe.Ingredients,
            Description = recipe.Description
        };
    }

    public static Recipe ToEntity(this UpdateRecipeDto recipe, int id)
    {
        return new Recipe()
        {
            Id = id,
            Name = recipe.Name,
            CuisineId = recipe.CuisineId,
            CookTime = recipe.CookTime,
            Ingredients = recipe.Ingredients,
            Description = recipe.Description
        };
    }

    public static RecipeSummaryDto ToRecipeSummaryDto(this Recipe recipe)
    {
        return new(
                recipe.Id,
                recipe.Name,
                recipe.Cuisine!.Name,
                recipe.CookTime,
                recipe.Ingredients!,
                recipe.Description!
            );
    }

    public static RecipeDetailedDto ToRecipeDetailedDto(this Recipe recipe)
    {
        return new(
                recipe.Id,
                recipe.Name,
                recipe.CuisineId,
                recipe.CookTime,
                recipe.Ingredients!,
                recipe.Description!
            );
    }
}
