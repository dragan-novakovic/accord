
public abstract class MessageRepository
{
    public abstract Task CreateAsync(MessageModel newMessage);
    public abstract Task<List<MessageModel>> GetAsync();
}