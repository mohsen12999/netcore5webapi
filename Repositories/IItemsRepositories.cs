using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepositories
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreatedItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
    }
}