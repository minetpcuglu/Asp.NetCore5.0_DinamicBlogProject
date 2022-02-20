using AutoMapper;
using BlogApiDemo.DataAccessLayer;
using BlogApiDemo.DataAccessLayer.Repository.EntityTypeRepository.Interface;
using BlogApiDemo.Models;
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

        private readonly IMapper _mapper;
        //private readonly IEmployeeRepository _employeeRepository;
        public DefaultController(IMapper mapper/*, IEmployeeRepository employeeRepository*/)
        {
            //_employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var value = c.Employees.ToList();
     
            return Ok(value); //basarılı status kodu : "200"

        }



        [HttpPost]
        public IActionResult EmployeeAdd(EmployeeVM employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }


        [HttpPost]
        [Route("EmployeeUpdate")]
        public async Task<IActionResult> EmployeeUpdate(EmployeeVM employeeVM)
        {
            using var c = new Context();
            var emp = await c.FindAsync<Employee>(employeeVM.Id);
            var update = _mapper.Map<Employee>(emp);
            if (update == null)
            {
                return NotFound();
            }
            else
            {
                update.Name = employeeVM.Name;
                c.Update(update);
                c.SaveChanges();
                return Ok();
            }


        }
    }
}
