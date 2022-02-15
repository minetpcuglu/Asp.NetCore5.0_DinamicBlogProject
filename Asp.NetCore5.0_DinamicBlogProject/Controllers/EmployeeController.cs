using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;
        public EmployeeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("");
            var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

       
    }
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
