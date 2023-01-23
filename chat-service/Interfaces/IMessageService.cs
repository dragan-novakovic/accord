
public abstract class IMessageService
{
    // public abstract Task<List<MessageModel>> GetAsync();
    public abstract Task CreateAsync(BaseNewMessage newMessage);
}