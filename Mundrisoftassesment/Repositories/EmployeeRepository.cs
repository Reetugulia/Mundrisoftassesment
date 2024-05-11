using Mundrisoftassesment.Data;
using Mundrisoftassesment.Models;
using System.ComponentModel.DataAnnotations;

namespace Mundrisoftassesment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int AddEmployee(Employee emp)
        {
            _db.Employee.Add(emp);
            int result=_db.SaveChanges();
            return result;
            
        }

        public int DeleteEmployee(int id)
        {
          int result=0;
            var emp=_db.Employee.Where(x=>x.Id==id).FirstOrDefault();
            if (emp!=null) 
            { 
                _db.Employee.Remove(emp);
                result=_db.SaveChanges();
            }
            return result;
        }

        public Employee GetEmployeeById(int id)
        {
          var emp=_db.Employee.Where(x=>x.Id==id).FirstOrDefault();
            return emp;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return _db.Employee.ToList();
        }

        public int ModifyEmployeeDetail(Employee employee)
        {
            int result = 0;
            Employee emp = new Employee();
            emp = _db.Employee.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.City = employee.City;
                emp.DepartmentId = employee.DepartmentId;
                result = _db.SaveChanges();
            }
            return result;
        }

       

       
    }
}
