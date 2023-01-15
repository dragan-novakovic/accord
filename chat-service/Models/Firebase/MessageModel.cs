
using Google.Cloud.Firestore;
/// <summary>
/// Record class that represents a message .
/// </summary>
[FirestoreData]
public record Message(
    [property: FirestoreProperty] string Name,
    [property: FirestoreProperty] string State
)
{
    /// <summary>
    /// The Google APIs require a default, parameterless constructor to work.
    /// </summary>
    public Message() : this("", "") { }
}