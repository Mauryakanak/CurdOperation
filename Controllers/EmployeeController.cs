using Microsoft.AspNetCore.Mvc;
using Employees.DataRepository;
using Employees.DataRepository.Interface;
using Employee_Model;

namespace Employee_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee repository;

        public EmployeeController(IEmployee _repository)
        {
            repository = _repository;
        }

        [Route("api/GetAllEmployee")]
        [HttpGet]
        public IEnumerable<EmployeeDetailsModel> GetAllEmployee()
        {
            return repository.GetAllEmployee();
        }

        [Route("api/AddEmployee")]
        [HttpPost]
        public void AddEmployee(EmployeeDetailsModel employee)
        {
            repository.AddEmployee(employee);
        }

        [Route("api/UpdateEmployee")]
        [HttpPut]
        public void UpdateEmployee(EmployeeDetailsModel employee)
        {
            repository.UpdateEmployee(employee);
        }

        [Route("api/DeleteEmployee")]
        [HttpDelete]
        public void DeleteEmployee(int EmployeeId)
        {
            repository.DeleteEmployee(EmployeeId);
        }

        [Route("api/GetEmployeeById")]
        [HttpGet]
        public EmployeeDetailsModel GetEmployeeById(int EmployeeId)
        {
            return repository.GetAllEmployeeById(EmployeeId);
        }
    }
}

