
using Google.Cloud.Firestore;



public class FirebaseMessage : BaseNewMessage
{

    public string message { get; set; }
    public string userId { get; set; }
    public string receiverId { get; set; }
    public FirebaseMessage(string _userId, string _reveiverId, string _message)
    {
        userId = _userId;
        receiverId = _reveiverId;
        message = _message;
    }


    public Dictionary<string, object> convertToDictonary()
    {
        return new Dictionary<string, object>
{
    { "fromId", this.userId },
    { "toId", this.receiverId },
    { "content", this.message }
};
    }

}