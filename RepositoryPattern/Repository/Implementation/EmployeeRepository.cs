using RepositoryPattern.Models;
using RepositoryPattern.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.Repository.Implementation
{
    public class EmployeeRepository :  GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly SampleDBEntities _context;

        public EmployeeRepository(SampleDBEntities context) : base(context)
        {
            this._context = context;
        }

        /// <summary>
        /// Get all available employees
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetEmployees()
        {
            return GetAll().AsQueryable();
        }

        /// <summary>
        /// Get employee by employee Id
        /// </summary>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            return GetById(id);
        }

        public void AddEmployee(Employee employee)
        {
            Insert(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
    }
}