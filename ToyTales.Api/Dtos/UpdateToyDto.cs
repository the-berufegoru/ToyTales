namespace ToyTales.Api.Dtos;

public record class UpdateToyDto
(
    string Name,
    string Category,
    decimal Price
);