using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Services
{
    public interface IDepartmentServices
    {
        IEnumerable<Department> GetAllDepartmentList();
        Department GetDepartmentById(int id);
        int AddDepartment(Department dep);
        int ModifyDepartment(Department dep);
        int DeleteDepartment(int id);
    }
}
