
public abstract class IMessageService
{
    public abstract Task<List<BaseMessage>> GetAsync();
    public abstract Task CreateAsync(BaseNewMessage newMessage);
}