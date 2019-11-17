using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.ViewModel
{
    public class DepartmentViewModel
    {
        [Key]
        [Column(Order = 0)]
        public int DeptId { get; set; } 

        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Please enter a Department Name")]
        public string DeptartmentName { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "Please enter a Location")]
        public string Location { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Heading { get; set; }
    }
}