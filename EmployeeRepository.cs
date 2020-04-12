using Dapper;
using Employee.Service.Interface.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnitOfWork;

namespace Employee.Service.Interface.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<EmployeeRepository> logger;
        public EmployeeRepository(IUnitOfWork unitOfWork, ILogger<EmployeeRepository> logger)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// <see cref="IEmployeeRepository.CreateEmployeeAsync(Entities.Employee)"/>
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<int> CreateEmployeeAsync(Entities.Employee employee)
        {
            var employeeJson = JsonSerializer.Serialize(employee);

            logger.LogInformation($"Going to create employee {employeeJson}");

            var employeeId = await unitOfWork.Connection.QueryFirstOrDefaultAsync<Int32>
                  (
                      "[dbo].[spEmployeeCreate]",
                      employee,
                      transaction: unitOfWork.Transaction,
                      commandType: CommandType.StoredProcedure
                  );
            logger.LogInformation($"Employee created successfully with employeeId {employeeId}");
            return employeeId;
        }

        /// <summary>
        /// <see cref="IEmployeeRepository.GetEmployeesAsync"/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Entities.Employee>> GetEmployeesAsync()
        {
            logger.LogInformation("Retrieve all employees");

            var employees = await unitOfWork.Connection.QueryAsync<Entities.Employee>
                (
                    "[dbo].[spGetEmployees]",
                    transaction: unitOfWork.Transaction,
                    commandType: CommandType.StoredProcedure
                );

            logger.LogInformation($"Total Employees found {employees.Count()}");

            return employees;

        }
        /// <summary>
        /// <see cref="IEmployeeRepository.GetEmployeesByIdAsync(int)"/>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Entities.Employee> GetEmployeesByIdAsync(Int32 employeeId)
        {
            logger.LogInformation($"Retrieve employees by id {employeeId}");

            var employees = await unitOfWork.Connection.QueryFirstOrDefaultAsync<Entities.Employee>
                (
                    "[dbo].[spGetEmployeeById]",
                    new {id=employeeId},
                    transaction: unitOfWork.Transaction,
                    commandType: CommandType.StoredProcedure
                );

            return employees;

        }
    }
}
