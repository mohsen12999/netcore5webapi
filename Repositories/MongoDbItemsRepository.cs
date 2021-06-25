using System;
using System.Collections.Generic;
using MongoDB.Driver;

using Catalog.Entities;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepositories
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemCollection;

        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemCollection = database.GetCollection<Item>(collectionName);
        }

        public void CreatedItem(Item item)
        {
            itemCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}