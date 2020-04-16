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

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string Department { get; set; }
        
        [Required]
        public int Salary { get; set; }
    }
}
