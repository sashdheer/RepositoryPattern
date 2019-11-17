using RepositoryPattern.Models;
using System.Collections.Generic;

namespace RepositoryPattern.Repository.Interface
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int deptId);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
    }
}
