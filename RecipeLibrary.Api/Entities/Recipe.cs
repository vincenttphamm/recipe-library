namespace RecipeLibrary.Api.Entities;

public class Recipe
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int CuisineId { get; set; }

    public Cuisine? Cuisine { get; set; }

    public int CookTime { get; set; }

    public string? Ingredients { get; set; }

    public string? Description { get; set; }
}
