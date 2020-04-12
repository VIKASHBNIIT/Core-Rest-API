using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Dto
{
    public class EmployeeCreateDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Employee Name is requierd")]
        public string Name { get; set; }
        [Required(ErrorMessage ="City is required")]
        public string City { get; set; }
        [Required(ErrorMessage ="Department is required")]
        public int Department { get; set; }
    }
}
