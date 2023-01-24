using Google.Cloud.Firestore;
using MongoDB.Driver;

public class MessageService : IMessageService
{
    //figure something better
    private readonly IMongoClient? _db_mongodb;
    private readonly FirestoreDb? _db_firebase;
    private readonly MessageRepository _messageRepository;

    public MessageService(IMongoClient mongoClient)
    {
        _db_mongodb = mongoClient;
        _messageRepository = new Mongodb_MessageRepository(_db_mongodb);
    }

    public MessageService(FirestoreDb firebaseClient)
    {
        _db_firebase = firebaseClient;
        _messageRepository = new Firebase_MessageRepository(_db_firebase);
    }

    override public async Task CreateAsync(BaseNewMessage newMessage)
    {
        await _messageRepository.CreateAsync(newMessage);

    }
    override public async Task<BaseMessage> GetAsync()
    {
        List<BaseMessage> messages = _messageRepository.GetAsync();

    }
}