using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Catalog.Api.Repositories;
using Catalog.Api.Entities;
using Catalog.Api.Dtos;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepositories repository;
        private readonly ILogger<ItemsController> logger;

        public ItemsController(IItemsRepositories repository, ILogger<ItemsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        // GET /items
        // GET /items?name=potion
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync(string name = null)
        {
            var items = (await repository.GetItemsAsync())
                            .Select(item => item.AsDto());

            if (!string.IsNullOrWhiteSpace(name))
            {
                items.Where(items => items.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrived {items.Count()} items");
            return items;
        }

        // GET /item/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreatedItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.Now
            };

            await repository.CreatedItemAsync(item);

            return CreatedAtAction(nameof(GetItemsAsync), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Name = itemDto.Name;
            existingItem.Price = itemDto.Price;

            await repository.UpdateItemAsync(existingItem);

            return NoContent();
        }


        // DELETE /item/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}