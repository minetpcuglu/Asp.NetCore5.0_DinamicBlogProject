using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    public class EmployeeController : Controller
    {
        //readonly HttpClient _httpClient;
        //public EmployeeController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}
       
        public async Task<IActionResult> Index()
        {

            var _httpClient = new HttpClient();

            var responseMessage = await _httpClient.GetAsync("https://localhost:44363/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString); //listelerken
            return View(values);
        }


        public IActionResult AddEmployee()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee( Employee employee)
        {
            var _httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(employee); //eklersen 
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:44363/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        } 

    }
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
