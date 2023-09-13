using CasesControl.Database;
using CasesControl.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CasesControl.Repository;

public class CaseRepository
{
    private readonly IMongoCollection<Case> _caseCollection;

    public CaseRepository(MongoDbConnector mongoDbConnector)
    {
        var mongoDbConnector1 = mongoDbConnector;
        mongoDbConnector1.ConnectionSetup();

        _caseCollection = mongoDbConnector1.GetCollection("cases");
    }

    public void AddCase(Case newCase)
    {
        _caseCollection.InsertOne(newCase);
    }

    public List<Case> GetAllCases()
    {
        List<Case> allCases = _caseCollection
            .Find(_ => true)
            .ToList();
        return allCases;
    }

    public List<Case> GetCasesByFilter(FilterDefinition<Case> filter)
    {
        List<Case> casesByFilter = _caseCollection.Find(filter).ToList();
        return casesByFilter;
    }
    
    
}