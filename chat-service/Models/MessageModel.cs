using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MessageModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    [BsonElement("message")]
    public string messageContent { get; set; } = null!;
    public string roomId { get; set; } = null!;
    public string username { get; set; } = null!;
}