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

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
    }
}