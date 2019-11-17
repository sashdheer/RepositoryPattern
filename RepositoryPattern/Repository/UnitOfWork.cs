using RepositoryPattern.Models;
using RepositoryPattern.Repository.Implementation;
using RepositoryPattern.Repository.Interface;

namespace RepositoryPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleDBEntities _context;

        public IEmployeeRepository Employees { get; private set; }
        public IDepartmentRepository Departments { get; private set; }

        public UnitOfWork(SampleDBEntities context)
        {
            _context = context;
            Employees = new EmployeeRepository(context);
            Departments = new DepartmentRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}