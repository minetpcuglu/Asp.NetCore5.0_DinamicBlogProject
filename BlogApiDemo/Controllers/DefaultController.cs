using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //veri listeleme

        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c= new Context();
            var value = c.Employees.ToList();
            return Ok(value); //basarılı status kodu : "200"

        }

        [HttpPost]
        public IActionResult EmployeeAdd()
        {
            return Ok();
        }



    }
}
