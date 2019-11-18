using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RepositoryPattern.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Firt Name")]
        [Required(ErrorMessage ="First Name is a required")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is a required")]
        public string LastName { get; set; }
        [DisplayName("Social Security Number")]
        [Required(ErrorMessage = "Social Security Number is a required")]
        public string SSN { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Modified By ")]
        public string ModifiedBy { get; set; }
        public string Heading { get; set; }

        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Department Name is a required")]
        public int DeptId { get; set; }
      
        public List<SelectListItem> DepartmentList { get; set; } //Use it to store the Departments.


    }
}