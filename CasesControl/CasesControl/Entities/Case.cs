using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CasesControl.Entities;

public class Case
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? LDAP { get; set; }
    public string? DataAtendimento { get; set; }
    public string? NumeroCaso { get; set; }
    public string? StatusAtendimento { get; set; }
    public string? NovoStatus { get; set; }
    public string? Tarefas { get; set; }
    public string? Print { get; set; }
    public string? Hora { get; set; }
    public string? Time { get; set; }
    
}
