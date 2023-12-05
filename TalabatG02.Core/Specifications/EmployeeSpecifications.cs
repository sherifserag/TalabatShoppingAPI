using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specifications
{
    public class EmployeeSpecifications:BaseSpecification<Employee>
    {
        public EmployeeSpecifications()
        {
            Includes.Add(E => E.Department);
        }
        public EmployeeSpecifications(int id):base(E=>E.Id == id)
        {
            Includes.Add(E => E.Department);
        }
    }
}
