using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Dtos
{
    // Data Transfer Object
    public record CreatedItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}