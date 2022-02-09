using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevsfairEmployeeController : ControllerBase
    {
        private static List<DevsfairEmployee> employees = new List<DevsfairEmployee>
            {
                new DevsfairEmployee{ EmployeeID = 1010101, EmployeeName = "Lisan Sojib", EmployeeAge = 32, EmployeePhone = "+880 17 xxx xxx xx", EmployeeDescription = "Founder"},
                new DevsfairEmployee{ EmployeeID = 1010110, EmployeeName = "Ratul Ali", EmployeeAge = 25, EmployeePhone = "+880 17 xxx xxx xx", EmployeeDescription = "Softweare Engineer I"},
                new DevsfairEmployee{ EmployeeID = 1010111, EmployeeName = "Md. Habibur Rahman", EmployeeAge = 27, EmployeePhone = "+880 17 xxx xxx xx", EmployeeDescription = "Softweare Engineer"}
            };

        [HttpGet]
        public async Task<ActionResult<List<DevsfairEmployee>>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("{employeeid}")]
        public async Task<ActionResult<List<DevsfairEmployee>>> Get(int employeeid)
        {
            var employee = employees.Find(h => h.EmployeeID == employeeid);
            if (employee == null)
                return BadRequest("Employee not found.");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<DevsfairEmployee>>> AddEmployee(DevsfairEmployee employee)
        {
            employees.Add(employee);
            return Ok(employees);
        }

        [HttpPut]
        public async Task<ActionResult<List<DevsfairEmployee>>> UpdateEmployee(DevsfairEmployee employee)
        {
            var employee = employees.Find(h => h.EmployeeID == employeeid);
            if (employee == null)
                return BadRequest("Employee not found.");
            employees.Add(employee);
            return Ok(employees);
        }
    }
}
