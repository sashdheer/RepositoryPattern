using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Models;
using RepositoryPattern.Repository.Interface;

namespace RepositoryPattern.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int Id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
