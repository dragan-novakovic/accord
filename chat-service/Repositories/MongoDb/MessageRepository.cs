using MongoDB.Bson;
using MongoDB.Driver;

public class Mongodb_MessageRepository : MessageRepository
{
    private readonly IMongoDatabase _db;
    private readonly IMongoCollection<MessageModel> _messagesCollection;

    public Mongodb_MessageRepository(IMongoClient mongoClient)
    {
        _db = mongoClient.GetDatabase("CHAT-SERVICE");
        _messagesCollection = _db.GetCollection<MessageModel>("messages");
    }

    public override async Task CreateAsync(BaseNewMessage newMessage) { await Task.Delay(2); }
    public override async Task<List<MessageModel>> GetAsync()
    {
        List<MessageModel> messages = await _messagesCollection.Find(new BsonDocument()).ToListAsync();
        return messages;
    }

}