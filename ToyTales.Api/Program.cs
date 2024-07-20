using ToyTales.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetToyEndpointName = "GetToy";

List<ToyDto> toys = [
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


// GET /toys
app.MapGet("toys", () => toys);

// GET /toys/6
app.MapGet("toys/{id}", (int id) => toys.Find(toy => toy.Id == id)).WithName(GetToyEndpointName);

// POST /toys
app.MapPost("toys",  (CreateToyDto newToy) => 
{
    ToyDto toy = new (
        toys.Count + 1,
        newToy.Name,
        newToy.Category,
        newToy.Price
    );

    toys.Add(toy);

    return Results.CreatedAtRoute(GetToyEndpointName, new { id = toy.Id}, toy);
});

app.Run();