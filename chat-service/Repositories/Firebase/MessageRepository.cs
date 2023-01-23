

using Google.Cloud.Firestore;

public class Firebase_MessageRepository : MessageRepository
{
    private readonly FirestoreDb _db;
    private readonly CollectionReference _messagesCollection;

    public Firebase_MessageRepository(FirestoreDb firebaseClient)
    {
        _db = firebaseClient;
        _messagesCollection = _db.Collection("messages");
    }

    public override async Task CreateAsync(BaseNewMessage newMessage) { await Task.Delay(2); }

}