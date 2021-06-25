using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

using Catalog.Entities;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepositories
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

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
            var filter = filterBuilder.Eq(item => item.Id, id);
            itemCollection.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemCollection.ReplaceOne(filter, item);
        }
    }
}