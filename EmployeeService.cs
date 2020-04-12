using Employee.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        /// <summary>
        /// <see cref="IEmployeeService.CreateEmployeeAsync(Interface.Entities.Employee)"/>
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<int> CreateEmployeeAsync(Interface.Entities.Employee employee)
        {
           return await employeeRepository.CreateEmployeeAsync(employee);
        }

        /// <summary>
        /// <see cref="IEmployeeService.GetAllEmployeesAsync"/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Interface.Entities.Employee>> GetAllEmployeesAsync()
        {
            return await employeeRepository.GetEmployeesAsync();
        }
        /// <summary>
        /// <see cref="IEmployeeService.GetEmployeesByIdAsync(int)"/>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Interface.Entities.Employee> GetEmployeesByIdAsync(int employeeId)
        {
            return await employeeRepository.GetEmployeesByIdAsync(employeeId);
        }
    }
}
