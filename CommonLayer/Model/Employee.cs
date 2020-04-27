//
// Purpose: Employee Details getter setter
// Author Vinayak Ushakola
// Date 16/04/2020
//

using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Model
{
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(15, MinimumLength = 3)]

        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",  ErrorMessage = "Please Enter Upper/Lower case Alphabets only!")]
        public string FirstName { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please Enter Upper/Lower case Alphabets only!")]
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 1)]
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please Enter Male/Female or M/F only!")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter Valid Email Address!")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please Enter Male/Female or M/F only!")]
        public string Department { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]+$",  ErrorMessage = "Your Salary should be numbers only!")]
        public int Salary { get; set; }
    }
}
