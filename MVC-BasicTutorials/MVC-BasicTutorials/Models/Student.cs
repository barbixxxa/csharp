using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_BasicTutorials.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public Gender StudentGender { get; set; }
        public bool isNewlyEnrolled { get; set; }
        public string Password { get; set; }
        public DateTime DoB { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}