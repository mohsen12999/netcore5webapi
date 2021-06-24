using System;

namespace Catalog.Dtos
{
    // Data Transfer Object
    public record CreatedItemDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}