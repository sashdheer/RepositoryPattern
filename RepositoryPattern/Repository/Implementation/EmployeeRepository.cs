using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Models;
using RepositoryPattern.ViewModel;

namespace RepositoryPattern.Repository.Implementation
{
    public class EmployeeRepository :  GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        /// <summary>
        /// Get all available employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return GetAll().ToList();
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