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
        //_messageRepository = new MessageRepository(_db_mongodb);
    }

    override public async Task CreateAsync(BaseNewMessage newMessage)
    {
        if (_db_mongodb is not null)
        {
            await _messageRepository.CreateAsync(new BaseNewMessage());
        }

        if (_db_firebase is not null)
        {



        }
    }
}