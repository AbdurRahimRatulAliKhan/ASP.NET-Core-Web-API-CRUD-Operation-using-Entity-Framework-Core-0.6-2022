using CoreServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly DataContext _context;

        public DevsfairEmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DevsfairEmployee>>> Get()
        {
            return Ok(await _context.DevsfairEmployees.ToListAsync());
        }

        [HttpGet("{employeeid}")]
        public async Task<ActionResult<List<DevsfairEmployee>>> Get(int employeeid)
        {
            //var employee = employees.Find(h => h.EmployeeID == employeeid);
            var employee = await _context.DevsfairEmployees.FindAsync(employeeid);
            if (employee == null)
                return BadRequest("Employee not found.");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<DevsfairEmployee>>> AddEmployee(DevsfairEmployee employee)
        {
            _context.DevsfairEmployees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.DevsfairEmployees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<DevsfairEmployee>>> UpdateEmployee(DevsfairEmployee request)
        {
            var employee = await _context.DevsfairEmployees.FindAsync(request.EmployeeID);
            if (employee == null)
                return BadRequest("Employee not found.");

            //employee.EmployeeID = request.EmployeeID;
            employee.EmployeeName = request.EmployeeName;
            employee.EmployeeAge = request.EmployeeAge;
            employee.EmployeePhone = request.EmployeePhone;
            employee.EmployeeDescription = request.EmployeeDescription;

            return Ok(await _context.DevsfairEmployees.ToListAsync());
        }

        [HttpDelete("{employeeid}")]
        public async Task<ActionResult<List<DevsfairEmployee>>> Delete(int employeeid)
        {
            var employee = employees.Find(h => h.EmployeeID == employeeid);
            if (employee == null)
                return BadRequest("Employee not found.");
            employees.Remove(employee);
            return Ok(employee);
        }
    }
}
