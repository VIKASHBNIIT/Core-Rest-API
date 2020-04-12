using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Service.Interface.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Entities.Employee>> GetEmployeesAsync();
        Task<Int32> CreateEmployeeAsync(Entities.Employee employee);
        Task<Entities.Employee> GetEmployeesByIdAsync(Int32 EmployeeID);

    }
}
