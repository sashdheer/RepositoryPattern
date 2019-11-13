using RepositoryPattern.Models;
using System.Web.Mvc;
using RepositoryPattern.ViewModel;
using System.Collections.Generic;


namespace RepositoryPattern.Controllers
{
   
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Employees
        public ActionResult Index()
        {
            var employees = _unitOfWork.Employees.GetEmployees();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeViewModel>>(employees);
           
            return View(viewModel);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = _unitOfWork.Employees.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            /*
            var employeeViewModel = new EmployeeViewModel
            {
                Heading = "Edit Employee",
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                CreatedBy = employee.CreatedBy,
                ModifiedBy = employee.ModifiedBy
            };
            */

            // using the automapper.
            var viewModel = AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employee);
            viewModel.Heading = "Edit Employee Details";
            return View("Details", viewModel);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var employeeViewModel = new EmployeeViewModel
            {
                Heading = "New Employee"
            };

            return View("Create", employeeViewModel);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", employeeViewModel);
            }

            var employee = new Employee
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                SSN = employeeViewModel.SSN,
                CreatedBy = employeeViewModel.CreatedBy,
                ModifiedBy = employeeViewModel.ModifiedBy
            };
            _unitOfWork.Employees.AddEmployee(employee);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Employees");
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee =_unitOfWork.Employees.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeViewModel = new EmployeeViewModel
            {
                Heading = "Edit Employee",
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                SSN = employee.SSN,
                CreatedBy = employee.CreatedBy,
                ModifiedBy = employee.ModifiedBy
            };
            return View("Edit", employeeViewModel);
        }

        // POST: Employees/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", employeeViewModel);
            }

            var employee = _unitOfWork.Employees.GetEmployee(employeeViewModel.Id);
            employee.Id = employeeViewModel.Id;
            employee.FirstName = employeeViewModel.FirstName;
            employee.LastName = employeeViewModel.LastName;
            employee.SSN = employeeViewModel.SSN;
            employee.CreatedBy = employeeViewModel.CreatedBy;
            employee.ModifiedBy = employeeViewModel.ModifiedBy;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Employees");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = _unitOfWork.Employees.GetEmployee(id);
            _unitOfWork.Employees.DeleteEmployee(employee);
            _unitOfWork.Complete();
            return RedirectToAction("Index");

        }
    }
}
