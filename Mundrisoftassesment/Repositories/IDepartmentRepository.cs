using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartmentList();
        Department GetDepartmentById(int id);
        int AddDepartment(Department dep);
        int ModifyDepartment(Department dep);
        int DeleteDepartment(int id);
    }
}
