using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employee.Service.Interface.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitOfWork;

namespace Employee.API.Controllers
{
    [Produces("application/json")]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly ILogger<EmployeeController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public EmployeeController
        (
                IEmployeeService employeeService,
                ILogger<EmployeeController> logger,
                IUnitOfWork unitOfWork,
                IMapper mapper
        )
        {
            this.employeeService = employeeService;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("employees")]
        public async Task<IEnumerable<Model.Employee>> GetAllEmployees()
        {
            logger.LogInformation("Getting All Employees");

            using (var work = unitOfWork.Begin())
            {
                try
                {
                    var employees = await employeeService.GetAllEmployeesAsync();

                    var employeesDto = employees != null ? mapper.Map<List<Model.Employee>>(employees)
                          : new List<Model.Employee>();

                    work.Commit();
                    return employeesDto;
                }
                catch (Exception ex)
                {
                    work.Rollback();
                    logger.LogError($"Error occured while getting employee {ex.Message}");
                    return null;
                }

            }
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Model.Employee>> GetEmployeesByID(Int32 employeeId)
        {
            logger.LogInformation("Getting  Employee by Id");

            using (var work = unitOfWork.Begin())
            {
                try
                {                   
                    var  employee= await employeeService.GetEmployeesByIdAsync(employeeId);
                   var employeeDto= employee != null ? mapper.Map<Model.Employee>(employee): new Model.Employee();
                    work.Commit();
                    return Ok(employeeDto);
                }
                catch (Exception ex)
                {
                    work.Rollback();
                    logger.LogError($"Error occured while getting employee {ex.Message}");
                    return null;
                }

            }
        }
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Dto.EmployeeCreateDto>> CreateEmployee([FromBody] Dto.EmployeeCreateDto employeeCreateDto)
        {
            logger.LogInformation("Creating Employee");

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var work = unitOfWork.Begin())
            {
                try
                {
                    var employeeDto = mapper.Map<Service.Interface.Entities.Employee>(employeeCreateDto);
                    var employeeId = await employeeService.CreateEmployeeAsync(employeeDto);
                    employeeCreateDto.ID = employeeId;
                    work.Commit();

                    return Ok(employeeCreateDto);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Error while creating employee {ex.Message}");
                    work.Rollback();
                    return BadRequest(ex.Message);
                }
            }

        }
    }
}