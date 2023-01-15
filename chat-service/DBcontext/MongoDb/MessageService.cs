using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

public class MessageService : IMessageService
{
    private readonly IMongoDatabase _db;
    private readonly IMongoCollection<MessageModel> _messagesCollection;

    public MessageService(IMongoClient mongoClient)
    {
        _db = mongoClient.GetDatabase("CHAT-SERVICE");
        _messagesCollection = _db.GetCollection<MessageModel>("messages");
    }


    override public async Task<List<MessageModel>> GetAsync() =>
        await _messagesCollection.Find(_ => true).ToListAsync();

    // public async Task<Book?> GetAsync(string id) =>
    //     await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    override public async Task CreateAsync(MessageModel newMessage) =>
        await _messagesCollection.InsertOneAsync(newMessage);

    // public async Task UpdateAsync(string id, Book updatedBook) =>
    //     await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    // public async Task RemoveAsync(string id) =>
    //     await _booksCollection.DeleteOneAsync(x => x.Id == id);
}