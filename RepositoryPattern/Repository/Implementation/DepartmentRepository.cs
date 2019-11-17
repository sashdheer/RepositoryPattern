using RepositoryPattern.Models;
using RepositoryPattern.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPattern.Repository.Implementation
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly SampleDBEntities _context;

        public DepartmentRepository(SampleDBEntities context) : base(context)
        {
            this._context = context;
        }
        public void AddDepartment(Department department)
        {
            Insert(department);
        }
        public void DeleteDepartment(Department department)
        {
            Delete(department);
        }
        public Department GetDepartment(int deptId)
        {
            return GetById(deptId);
        }
        public IEnumerable<Department> GetDepartments()
        {
            return GetAll().ToList();
        }
        public void UpdateDepartment(Department department)
        {
            Update(department);
        }
    }
}