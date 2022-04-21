using MongoDB.Driver;
using MongoDB.Bson;

public class MessageService
{
    private readonly IMongoCollection<BsonDocument>? messages;
    public MessageService(IMongoClient mongoClient)
    {
        IMongoDatabase db = mongoClient.GetDatabase("DatabaseName");
        messages = db.GetCollection<BsonDocument>("messages");

        Console.WriteLine("A", messages);
    }
}