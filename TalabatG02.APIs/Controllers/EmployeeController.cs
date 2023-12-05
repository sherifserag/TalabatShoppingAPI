using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specifications;

namespace TalabatG02.APIs.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        private readonly IGenericRepository<Employee> empRepo;

        public EmployeeController(IGenericRepository<Employee> empRepo)
        {
            this.empRepo = empRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployees()
        {
            var spec = new EmployeeSpecifications();
            var Employees = empRepo.GetAllWithSpecAsync(spec);

            return Ok(Employees);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var spec = new EmployeeSpecifications(id);
            var employee = empRepo.GetByIdWithSpecAsync(spec);

            return Ok(employee);

        }


    }
}
