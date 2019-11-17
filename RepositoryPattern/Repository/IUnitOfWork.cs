using RepositoryPattern.Repository.Interface;
using System;

namespace RepositoryPattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        void Complete();
    }
}