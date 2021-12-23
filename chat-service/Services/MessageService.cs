using MongoDB.Driver;

public class MessageService
{
    private readonly IMongoCollection<Message>? messages;
    public MessageService(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase("DatabaseName");
        messages = database.GetCollection<Message>("messages");
    }
}