using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Catalog.Repositories;
using Catalog.Entities;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepositories repository;

        public ItemsController()
        {
            repository = new InMemItemsRepositories();
        }

        // GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        // GET /item/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }
    }
}