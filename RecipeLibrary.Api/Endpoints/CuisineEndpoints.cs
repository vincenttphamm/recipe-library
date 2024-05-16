using Microsoft.EntityFrameworkCore;
using RecipeLibrary.Api.Mapping;

namespace RecipeLibrary.Api.Endpoints;

public static class CuisineEndpoints
{
    public static RouteGroupBuilder MapCuisinesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("cuisines");

        group.MapGet("/", async (RecipeLibraryContext dbContext) =>
            await dbContext.Cuisines.Select(cuisine => cuisine.ToDto())
            .AsNoTracking().ToListAsync());

        return group;
    }
}
