using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Mapping
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee.Service.Interface.Entities.Employee, Employee.API.Model.Employee>();
            CreateMap<Dto.EmployeeCreateDto,Employee.Service.Interface.Entities.Employee>();
        }
    }
}
