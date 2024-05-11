using Mundrisoftassesment.Models;
using Mundrisoftassesment.Repositories;

namespace Mundrisoftassesment.Services
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly IDepartmentRepository _reposit;
        public DepartmentService(IDepartmentRepository reposit)
        {
            _reposit = reposit;
        }
        public int AddDepartment(Department dep)
        {
           return _reposit.AddDepartment(dep);
        }

        public int DeleteDepartment(int id)
        {
            return (_reposit.DeleteDepartment(id));
        }

        public IEnumerable<Department> GetAllDepartmentList()
        {
           return _reposit.GetAllDepartmentList();
        }

        public Department GetDepartmentById(int id)
        {
            return _reposit.GetDepartmentById(id);
        }

        public int ModifyDepartment(Department dep)
        {
            return _reposit.ModifyDepartment(dep);  
        }
    }
}
