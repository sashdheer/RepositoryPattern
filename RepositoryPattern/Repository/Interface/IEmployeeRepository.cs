using RepositoryPattern.Models;
using RepositoryPattern.Repository.Interface;
using System.Collections.Generic;

namespace RepositoryPattern.Repository.Interface
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
