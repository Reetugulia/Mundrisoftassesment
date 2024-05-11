using Mundrisoftassesment.Models;
using Mundrisoftassesment.Repositories;
using Newtonsoft.Json;
using System.Net.Http;

namespace Mundrisoftassesment.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IEmployeeRepository _reposit;
		private readonly HttpClient httpClient;
		public  EmployeeService(IEmployeeRepository reposit)
        {
            _reposit = reposit;
            this.httpClient = httpClient;
        }
        public int AddEmployee(Employee employee)
        {
           return _reposit.AddEmployee(employee);
        }

        public int DeleteEmployee(int id)
        {
           return _reposit.DeleteEmployee(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return _reposit.GetEmployeeById(id);
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return _reposit.GetEmployeeList();
        }

        public int ModifyEmployeeDetail(Employee employee)
        {
            return _reposit.ModifyEmployeeDetail(employee);
        }
       
    }
}
