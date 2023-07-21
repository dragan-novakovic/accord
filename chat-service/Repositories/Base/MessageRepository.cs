
public abstract class MessageRepository<T>
{
    public abstract Task CreateAsync(BaseNewMessage newMessage);
    public abstract Task<List<T>> GetAsync();
}