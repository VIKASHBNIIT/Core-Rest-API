using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Service.Interface.Entities
{
   public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Department { get; set; }
    }
}
