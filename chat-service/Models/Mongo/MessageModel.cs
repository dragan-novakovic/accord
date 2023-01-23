using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MessageModel : BaseNewMessage
{

    public MessageModel(string MessageContent, string ChannelId, string Username)
    {
        messageContent = MessageContent;
        channelId = ChannelId;
        username = Username;
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    [BsonElement("message")]
    public string messageContent { get; set; } = null!;
    public string channelId { get; set; } = null!;
    public string username { get; set; } = null!;


    public override string ToString()
    {
        return $@"
    Message: {this.messageContent},
    RoomId: {this.channelId},
    Username: {this.username}
    ";
    }
}