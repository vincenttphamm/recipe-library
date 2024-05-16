namespace RecipeLibrary.Api.Dtos;

public record class RecipeSummaryDto(int Id,
 string Name,
  string Cuisine,
   int CookTime,
    string Ingredients,
     string Description);
