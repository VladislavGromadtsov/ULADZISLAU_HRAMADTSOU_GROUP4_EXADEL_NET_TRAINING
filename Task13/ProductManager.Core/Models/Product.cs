using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManager.Core.Models;

public class Product
{
    [BsonId]
    public Guid Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    public Audit AuditInfo { get; set; }

    [BsonElement("features")]
    public IEnumerable<string> Features { get; set; }
}
