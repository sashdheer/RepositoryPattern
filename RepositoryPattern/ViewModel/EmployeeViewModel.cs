using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPattern.ViewModel
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SSN { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string Heading { get; set; }


    }
}