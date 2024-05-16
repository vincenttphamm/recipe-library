using RecipeLibrary.Api.Dtos;
using RecipeLibrary.Api.Entities;

namespace RecipeLibrary.Api.Mapping;

public static class CuisineMapping
{
    public static CuisineDto ToDto(this Cuisine cuisine)
    {
        return new CuisineDto(cuisine.Id, cuisine.Name);
    }
}
