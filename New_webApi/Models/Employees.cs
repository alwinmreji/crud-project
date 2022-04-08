
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_webApi.Models
{
    public class Employees
    {

         [Required]
       
        public string Name
        {
            get;
            set;
        }

        [Required]
        public string Emp_ID
        {
            get;
            set;
        }
        

        [Required]
        public string Designation
        {
            get;
            set;
        }

        [Required]
        public string Department
        {
            get;
            set;
        }

        public string DOB
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Salary
        {
            get;
            set;
        }

    }
}