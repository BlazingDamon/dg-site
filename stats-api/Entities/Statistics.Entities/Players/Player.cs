using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Statistics.Entities.Players;

public class Player
{
    [BsonIgnoreIfDefault]
    public ObjectId? Id { get; set; }
    public string? PlayerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int EventsCompleted { get; set; }
    public int Wins { get; set; }
}