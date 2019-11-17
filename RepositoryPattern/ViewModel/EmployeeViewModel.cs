using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace RepositoryPattern.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Firt Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Social Security Number")]
        public string SSN { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Modified By ")]
        public string ModifiedBy { get; set; }
        public string Heading { get; set; }

        public int DeptId { get; set; }

        [DisplayName("Department Name")]
        public List<SelectListItem> DepartmentList { get; set; } //Use it to store the Departments.


    }
}