using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam2.Models
{
    public class Class1
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile")]

        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Your Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Your Zipcode")]
        public Nullable<int> Zipcode { get; set; }
        [Required(ErrorMessage = "Please Enter Your Salary")]
        public Nullable<int> Salary { get; set; }
    }
}