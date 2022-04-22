using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MessageModel
{

    public MessageModel(string MessageContent, string RoomId, string Username)
    {
        messageContent = MessageContent;
        roomId = RoomId;
        username = Username;
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    [BsonElement("message")]
    public string messageContent { get; set; } = null!;
    public string roomId { get; set; } = null!;
    public string username { get; set; } = null!;
}