
public class UserRepository : GenericRepository<UserMetadataModel>, IUserRepository
{
    public UserRepository(GenericDbContext _context) : base(_context)
    {
    }

    public IEnumerable<UserMetadataModel> GetUserMetadata(string userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserMetadataModel> GetUserMetadataModels()
    {
        throw new NotImplementedException();
    }
}