using System;
using System.Collections.Generic;

using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepositories
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreatedItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}