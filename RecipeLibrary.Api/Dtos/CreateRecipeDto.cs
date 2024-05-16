using System.ComponentModel.DataAnnotations;

namespace RecipeLibrary.Api.Dtos;

public record class CreateRecipeDto(
 [Required][StringLength(50)] string Name,
  int CuisineId,
   [Required][Range(1, 2880)] int CookTime,
    [Required][StringLength(500)] string Ingredients,
     [Required][StringLength(500)] string Description);
