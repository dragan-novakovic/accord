

public interface IUserRepository : IGenericRepository<UserMetadataModel>
{
    //Here, you need to define the operations which are specific to Room Entity
    IEnumerable<UserMetadataModel> GetUserMetadataModels();
    IEnumerable<UserMetadataModel> GetUserMetadata(string userId);
}