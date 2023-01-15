using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class IMessageService
{
    public abstract Task<List<MessageModel>> GetAsync();
    public abstract Task CreateAsync(MessageModel newMessage);
}