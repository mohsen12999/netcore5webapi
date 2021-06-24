using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    // Data Transfer Object
    public record UpdatedItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}