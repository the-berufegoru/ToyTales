namespace ToyTales.Api.Dtos;

public record class ToyDto(
    int Id,
    string Name,
    string Category,
    decimal Price
    );