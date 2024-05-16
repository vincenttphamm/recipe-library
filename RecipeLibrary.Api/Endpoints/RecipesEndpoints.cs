using Microsoft.EntityFrameworkCore;
using RecipeLibrary.Api.Dtos;
using RecipeLibrary.Api.Entities;
using RecipeLibrary.Api.Mapping;

namespace RecipeLibrary.Api.Endpoints;

public static class RecipesEndpoints
{
    const string GetRecipeEndpointName = "GetRecipe";

    public static RouteGroupBuilder MapRecipeEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("recipes").WithParameterValidation();

        // GET /recipes
        group.MapGet("/", async (RecipeLibraryContext dbContext) => await dbContext.Recipes.Include(recipe => recipe.Cuisine)
        .Select(recipe => recipe.ToRecipeSummaryDto())
        .AsNoTracking().ToListAsync());

        // GET /recipes/1
        group.MapGet("/{id}", async (int id, RecipeLibraryContext dbContext) =>
        {
            Recipe? recipe = await dbContext.Recipes.FindAsync(id);

            // If no recipe id matches input id, return results not found.
            if (recipe == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(recipe.ToRecipeDetailedDto());
            }
        })
        .WithName(GetRecipeEndpointName);

        // POST /recipes
        group.MapPost("/", async (CreateRecipeDto newRecipe, RecipeLibraryContext dbContext) =>
        {
            Recipe recipe = newRecipe.ToEntity();

            dbContext.Recipes.Add(recipe);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetRecipeEndpointName, new { id = recipe.Id }, recipe.ToRecipeDetailedDto());
        });

        // PUT /recipes/1
        group.MapPut("/{id}", async (int id, UpdateRecipeDto updatedRecipe, RecipeLibraryContext dbContext) =>
        {
            var existingRecipe = await dbContext.Recipes.FindAsync(id);

            // If no recipe id matches input id, return results not found.
            if (existingRecipe is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingRecipe).CurrentValues.SetValues(
                updatedRecipe.ToEntity(id)
            );

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /recipes/1
        group.MapDelete("/{id}", async (int id, RecipeLibraryContext dbContext) =>
        {
            await dbContext.Recipes.Where(recipe => recipe.Id == id)
            .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
