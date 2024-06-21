using System.Threading.Tasks;
using DapperCRUDApplication.Context;
using DapperCRUDApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DapperCRUDApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AutoValidateAntiforgeryToken]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("get/all")]
        public async Task<ActionResult> GetAll()
        {
            var res = await _employeeService.GetAll();
            return Ok(res);
        }

        [HttpGet("get")]
        public async Task<ActionResult> Get(int employeeId)
        {
            var res = await _employeeService.Get(employeeId);
            return Ok(res);
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(Employee employee)
        {
            var res = await _employeeService.AddAsync(employee);
            return Ok(res);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(Employee employee)
        {
            var res = await _employeeService.UpdateAsync(employee);
            return Ok(res);
        }


        [HttpPost("delete")]
        public async Task<ActionResult> Delete(int employeeId)
        {
            var data = await _employeeService.DeleteAsync(employeeId);
            return Ok(data);
        }

    }
}
