using Mundrisoftassesment.Data;
using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public int AddDepartment(Department dep)
        {
            _db.Department.Add(dep);
            var result=_db.SaveChanges();
            return result;
        }

        public int DeleteDepartment(int id)
        {
            int result = 0;
            var dpt = _db.Department.Where(x => x.DepartmentId == id).FirstOrDefault();
            if (dpt != null)
            {
                _db.Department.Remove(dpt);
                result = _db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Department> GetAllDepartmentList()
        {
            return _db.Department.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            var dpt = _db.Department.Where(x => x.DepartmentId == id).FirstOrDefault();
            return dpt;
        }

        public int ModifyDepartment(Department dep)
        {
            int result = 0;
            Department department = new Department();
            department = _db.Department.Where(x => x.DepartmentId == dep.DepartmentId).FirstOrDefault();
            if (department != null)
            {
                department.DepartmentName= dep.DepartmentName;
                result = _db.SaveChanges();
            }
            return result;
        }
    }
}
