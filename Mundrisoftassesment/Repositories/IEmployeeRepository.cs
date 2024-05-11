using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee GetEmployeeById(int id);
        int AddEmployee(Employee employee);
        int ModifyEmployeeDetail(Employee employee);
        int DeleteEmployee(int id);
        


    }
}
