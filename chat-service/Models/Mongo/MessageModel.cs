using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MessageModel : BaseNewMessage
{

    public MessageModel(string UserId, string ReceiverId, string MessageContent, string? RoomId)
    {
        this.UserId = UserId;
        this.ReceiverId = ReceiverId;
        this.MessageContent = MessageContent;
        this.RoomId = RoomId;
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    [BsonElement("message")]
    public string? RoomId { get; set; }
    public DateTime MessageCreated { get; set; }


    public override string ToString()
    {
        return $@"
    UserId: {this.UserId},
    Message: {this.MessageContent},
    RoomId: {this.RoomId},
    ";
    }
}