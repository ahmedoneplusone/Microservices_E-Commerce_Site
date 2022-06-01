using CatalogAPI.Data.Interfaces;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(ICatalogDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        
        public IMongoCollection<Product> Products {get;}
    }
}