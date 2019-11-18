using RepositoryPattern.Models;
using RepositoryPattern.Repository;
using RepositoryPattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPattern.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Department/Index")]
        public ActionResult Index()
        {
            var departments = _unitOfWork.Departments.GetDepartments();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);

            return View(viewModel);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            Department department = _unitOfWork.Departments.GetDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }
       
            // using the automapper.
            var viewModel = AutoMapper.Mapper.Map<Department, DepartmentViewModel>(department);
            return View("Details", viewModel);
        }


        // GET: Department/Create
        public ActionResult Create()
        {
            var departmentViewModel = new DepartmentViewModel
            {
                Heading = "New Department"
            };

            return View("Create", departmentViewModel);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", departmentViewModel);
            }

            var department = new Department
            {
                Name = departmentViewModel.DeptartmentName,
                Location = departmentViewModel.Location,
                CreatedBy = departmentViewModel.CreatedBy,
                ModifiedBy = departmentViewModel.ModifiedBy
            };
            _unitOfWork.Departments.AddDepartment(department);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Department");
        }



        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            Department department = _unitOfWork.Departments.GetDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            // using the automapper.
            var viewModel = AutoMapper.Mapper.Map<Department, DepartmentViewModel>(department);
            return View("Edit", viewModel);
        }

        // POST: Department/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", departmentViewModel);
            }

           // Department department = _unitOfWork.Departments.GetDepartment(id);

            var department = new Department
            {
                Name = departmentViewModel.DeptartmentName,
                Location = departmentViewModel.Location,
                CreatedBy = departmentViewModel.CreatedBy,
                ModifiedBy = departmentViewModel.ModifiedBy
            };

            _unitOfWork.Departments.UpdateDepartment(department);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Department");
        }

        // GET: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Department department = _unitOfWork.Departments.GetDepartment(id);
            _unitOfWork.Departments.DeleteDepartment(department);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Department");
        }
    }
}
