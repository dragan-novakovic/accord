
public class UserController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IGenericRepository<RoomModel> genericRepository;
    private readonly IUserRepository userService;
    public UserController()
    {
        this.roomRepository = new UserRepository();
        this.genericRepository = new GenericRepository<RoomModel>();
    }
    public UserController(EmployeeRepository repository)
    {
        this.employeeRepository = repository;
    }
    public EmployeeController(IGenericRepository<Employee> repository)
    {
        this.genericRepository = repository;
    }
    //The following Action Method will be called when you click on the Submit button on the Add Employee view
    [HttpPost]
    public ActionResult AddEmployee(Employee model)
    {
        //First Check whether the Model State is Valid or not
        if (ModelState.IsValid)
        {
            //If Model State is Valid, then call the Insert method GenericRepository to make the Entity State Added
            genericRepository.Insert(model);
            //To make the changes permanent in the database, call the Save method of GenericRepository
            genericRepository.Save();
            //Once the data is saved into the database, redirect to the Index View
            return RedirectToAction("Index", "Employee");
        }
        //If the Model state is not valid, then stay on the current AddEmployee view
        return View();
    }
    //The following Action Method will open the Edit Employee view based on the EmployeeId
    [HttpGet]
    public ActionResult EditEmployee(int EmployeeId)
    {
        //First, Fetch the Employee information by calling the GetById method of GenericRepository
        Employee model = genericRepository.GetById(EmployeeId);
        //Then Pass the Employee data to the Edit view
        return View(model);
    }
    //The following Action Method will be called when you click on the Submit button on the Edit Employee view
    [HttpPost]
    public ActionResult EditEmployee(Employee model)
    {
        //First Check whether the Model State is Valid or not
        if (ModelState.IsValid)
        {
            //If Valid, then call the Update Method of GenericRepository to make the Entity State Modified
            genericRepository.Update(model);
            //To make the changes permanent in the database, call the Save method of GenericRepository
            genericRepository.Save();
            //Once the updated data is saved into the database, redirect to the Index View
            return RedirectToAction("Index", "Employee");
        }
        else
        {
            //If the Model State is invalid, then stay on the same view
            return View(model);
        }
    }
    //The following Action Method will open the Delete Employee view based on the EmployeeId
    [HttpGet]
    public ActionResult DeleteEmployee(int EmployeeId)
    {
        //First, Fetch the Employee information by calling the GetById method of GenericRepository
        Employee model = genericRepository.GetById(EmployeeId);
        //Then Pass the Employee data to the Delete view
        return View(model);
    }
    //The following Action Method will be called when you click on the Submit button on the Delete Employee view
    [HttpPost]
    public ActionResult Delete(int EmployeeID)
    {
        //Call the Delete Method of the GenericRepository to Make the Entity State Deleted 
        genericRepository.Delete(EmployeeID);
        //Then Call the Save Method to delete the entity from the database permanently
        genericRepository.Save();
        //And finally, redirect the user to the Index View
        return RedirectToAction("Index", "Employee");
    }
}