using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

public class MessageService : IMessageService
{
    private IMongoDatabase _db;
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

    // public async Task CreateAsync(Book newBook) =>
    //     await _booksCollection.InsertOneAsync(newBook);

    // public async Task UpdateAsync(string id, Book updatedBook) =>
    //     await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    // public async Task RemoveAsync(string id) =>
    //     await _booksCollection.DeleteOneAsync(x => x.Id == id);
}