public abstract class IMessageService
{
    public abstract Task<List<MessageModel>> GetAsync();
}