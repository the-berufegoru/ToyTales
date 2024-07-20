using ToyTales.Api.Dtos;

namespace ToyTales.Api.Endpoints;

public static class ToysEndpoints
{
    const string GetToyEndpointName = "GetToy";

    private static readonly List<ToyDto> toys = [
         new (1, "Lego City", "Building Blocks", 29.99m),
            new (2, "Barbie Dreamhouse", "Dolls", 199.99m),
            new (3, "Hot Wheels Track", "Vehicles", 49.99m),
            new (4, "Nerf Blaster", "Outdoor Play", 34.99m),
            new (5, "Play-Doh Set", "Arts & Crafts", 14.99m),
            new (6, "Transformers Action Figure", "Action Figures", 24.99m),
            new (7, "Rubik's Cube", "Puzzles", 9.99m),
            new (8, "Fisher-Price Baby Gym", "Baby Toys", 39.99m),
            new (9, "Monopoly Board Game", "Board Games", 19.99m),
            new (10, "RC Car", "Remote Control Toys", 59.99m)

    ];

    public static RouteGroupBuilder MapToysEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("toys");

        // GET /toys
        group.MapGet("/", () => toys);

        // GET /toys/6
        group.MapGet("/{id}", (int id) =>
        {
            ToyDto? toy = toys.Find(toy => toy.Id == id);

            return toy is null ? Results.NotFound() : Results.Ok(toy);
        }).WithName(GetToyEndpointName);

        // POST /toys
        group.MapPost("/", (CreateToyDto newToy) =>
        {
            ToyDto toy = new(
                toys.Count + 1,
                newToy.Name,
                newToy.Category,
                newToy.Price
            );

            toys.Add(toy);

            return Results.CreatedAtRoute(GetToyEndpointName, new { id = toy.Id }, toy);
        });

        // PUT /toys/4
        group.MapPut("/{id}", (int id, UpdateToyDto updateToy) =>
        {
            var toyIndex = toys.FindIndex(toy => toy.Id == id);

            if (toyIndex == -1)
            {
                return Results.NotFound();
            }

            toys[toyIndex] = new ToyDto(
               id,
               updateToy.Name,
               updateToy.Category,
               updateToy.Price
            );

            return Results.NoContent();
        });

        // DELETE /toys/5
        group.MapDelete("/{id}", (int id) =>
        {
            toys.RemoveAll(toy => toy.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
