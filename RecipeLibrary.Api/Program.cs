using RecipeLibrary.Api;
using RecipeLibrary.Api.Data;
using RecipeLibrary.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("RecipeLibrary");
builder.Services.AddSqlite<RecipeLibraryContext>(connString);

var app = builder.Build();

app.MapRecipeEndpoints();

app.MapCuisinesEndpoints();

await app.MigrateDbAsync();

app.Run();
