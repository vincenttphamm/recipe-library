namespace RecipeLibrary.Api.Dtos;

public record class RecipeDetailedDto(int Id,
 string Name,
  int CuisineId,
   int CookTime,
    string Ingredients,
     string Description);
