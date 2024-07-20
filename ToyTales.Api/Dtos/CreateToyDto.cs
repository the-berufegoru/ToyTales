namespace ToyTales.Api.Dtos;

public record class CreateToyDto
(
    string Name,
    string Category,
    decimal Price
);