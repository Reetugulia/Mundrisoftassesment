using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee GetEmployeeById(int id);
        int AddEmployee(Employee employee);
        int ModifyEmployeeDetail(Employee employee);
        int DeleteEmployee(int id);
		


	}
}
