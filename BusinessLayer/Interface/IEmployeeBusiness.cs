//
// Purpose: Interface of the Business Layer
// Author Vinayak Ushakola
// Date 16/04/2020
//

using CommonLayer.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBusiness
    {
        List<Employee> Get();

        Employee Get(int id);

        int Add([FromBody]Employee employee);

        int Update(int id, [FromBody]Employee employee);

        int Delete(int id);
    }
}
