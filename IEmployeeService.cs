using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Interface.Repository
{
   public interface IEmployeeService
    {
        Task<IEnumerable<Entities.Employee>> GetAllEmployeesAsync();
        Task<Entities.Employee> GetEmployeesByIdAsync(Int32 employeeId);
        Task<Int32> CreateEmployeeAsync(Entities.Employee employee);
    }
}
