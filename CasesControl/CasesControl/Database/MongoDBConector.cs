using CasesControl.Entities;
using MongoDB.Driver;

namespace CasesControl.Database
{
    public class MongoDbConnector
    {
        private readonly IConfiguration _configuration;
        private IMongoDatabase _database;

        public MongoDbConnector(IConfiguration configuration, IMongoDatabase database)
        {
            _configuration = configuration;
            _database = database;
        }

        public void ConnectionSetup()
        {
            string? connectionString = _configuration.GetConnectionString("MongoDBConnection");
            string? databaseName = _configuration["DatabaseName"]; 
            MongoClient client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        
        public IMongoCollection<Case> GetCollection(string collectionName)
        {
            return _database.GetCollection<Case>(collectionName);
        }
    }
}