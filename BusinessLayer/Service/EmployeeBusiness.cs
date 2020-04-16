//
// Purpose: Business Layer for the Communication between Main Program and Repository Layer
// Author Vinayak Ushakola
// Date 16/04/2020
//

using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace BusinessLayer.Service
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        public IEmployeeRepository employeeRepository;

        public EmployeeBusiness(IEmployeeRepository iEmployeeRepository)
        {
            employeeRepository = iEmployeeRepository;
        }

        public List<Employee> Get()
        {
            return employeeRepository.Get();
        }

        public Employee Get(int id)
        {
            return employeeRepository.Get(id);
        }
        public int Add([FromBody]Employee employee)
        {
            return employeeRepository.Add(employee);
        }

        public int Delete(int id)
        {
            return employeeRepository.Delete(id);
        }

        public int Update(int id, [FromBody]Employee employee)
        {
            return employeeRepository.Update(id, employee);
        }
    }
}
