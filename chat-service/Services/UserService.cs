using MongoDB.Driver;

public class UserService : IMessageService
{
    private readonly MessageRepository _messageRepository;

    public UserService(IMongoClient mongoClient)
    {
        _messageRepository = new Mongodb_MessageRepository(mongoClient);
    }
    override public async Task CreateAsync(MessageModel newMessage)
    {

        Console.WriteLine("MESSAGE SERVICE HERE");
        await _messageRepository.CreateAsync(newMessage);


    }
    override public async Task<List<MessageModel>> GetAsync()
    {
        List<MessageModel> messages = await _messageRepository.GetAsync();
        return messages;
    }
}