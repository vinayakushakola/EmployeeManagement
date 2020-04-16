//
// Purpose: API of the Employee Management
// Author Vinayak Ushakola
// Date 16/04/2020
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using CommonLayer.Model;

namespace EmployeeManagement.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEmployeeBusiness employeeBusiness;

        public EmployeesController(IEmployeeBusiness iEmployeeBusiness)
        {
            employeeBusiness = iEmployeeBusiness;
        }

        /// <summary>
        /// It returns List of Employees Data from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            List<Employee> employees = employeeBusiness.Get();
            if (employees.Count == 0)
            {
                return NotFound("No Data Present");
            }
            return Ok(employees.ToList());
        }

        /// <summary>
        /// It returns the Specific ID Employee Data 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = employeeBusiness.Get(id);
            if (employee == null)
            {
                return NotFound("No Employee Data Present with this id");
            }
            return Ok(employee);
        }

        /// <summary>
        /// It adds the Employee Details to the Database
        /// </summary>
        /// <param name="employee">Employee Details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            int count = employeeBusiness.Add(employee);
            if (count == 0)
            {
                return Content(NoContent().ToString(), "Unable to Add Employee!");
            }
            return Ok("Employee Data Added Successfully");
        }

        /// <summary>
        /// It Updates the Employee Details in the Database
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="employee">Employee Details</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody]Employee employee)
        {
            int count = employeeBusiness.Update(id, employee);
            if (count == 0)
            {
                return NotFound("No Employee Data Present with this id");
            }
            return Ok("Employee data has Been Successfully Updated!");
        }

        /// <summary>
        /// It Deletes the Employee Details from the Database
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            int count = employeeBusiness.Delete(id);
            if (count == 0)
            {
                return NotFound("No Employee with this id");
            }
            return Ok("Employee data Deleted Successfully!");
        }
    }
}