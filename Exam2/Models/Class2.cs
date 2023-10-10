using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam2.Models
{
    public class Class2
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public int Password { get; set; }
    
        public int NewPassword { get; set; }

    }
}