using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace myFirstwebapplication.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        //       [Required(ErrorMessage = "Enter First Name")]
        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }
        [Range(5000,500000,ErrorMessage ="range 5000 - 500000")]
        public int? Salary { get; set; }
    }
    
}