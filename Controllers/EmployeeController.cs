using DapperCRUDApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<WeatherForecastController> logger,
            IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }


        [HttpGet("get")]
        public ActionResult Get(int id)
        {
            var res = _employeeService.Get(id);
            return Ok(res);
        }

        [HttpGet("get/all")]
        public ActionResult GetAll()
        {
            var res = _employeeService.GetAll();
            return Ok(res);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [HttpPost("edit")]
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        [HttpPost("edit/all")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [HttpPost("delete")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
