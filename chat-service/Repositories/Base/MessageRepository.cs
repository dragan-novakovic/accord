
public abstract class MessageRepository
{
    public abstract Task CreateAsync(BaseNewMessage newMessage);
    public abstract Task<List<MessageModel>> GetAsync();
}