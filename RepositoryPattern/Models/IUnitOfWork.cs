using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }

        void Complete();
    }
}