
public abstract class IRoomService
{
    public abstract Task<List<MessageModel>> GetAsync();
    public abstract Task CreateAsync(MessageModel newMessage);
}