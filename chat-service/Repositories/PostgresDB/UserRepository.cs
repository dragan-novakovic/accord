
public class UserRepository : GenericRepository<RoomModel>, IRoomRepository
{
    public IEnumerable<Employee> GetEmployeesByGender(string Gender)
    {
        return _context.Employees.Where(emp => emp.Gender == Gender).ToList();
    }
    public IEnumerable<Employee> GetEmployeesByDepartment(string Dept)
    {
        return _context.Employees.Where(emp => emp.Dept == Dept).ToList();
    }

    public IEnumerable<RoomModel> GetRooms()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RoomModel> GetRoomsForUser(string userId)
    {
        throw new NotImplementedException();
    }
}