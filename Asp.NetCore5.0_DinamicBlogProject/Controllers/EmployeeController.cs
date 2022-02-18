using Asp.NetCore5._0_DinamicBlogProject.Models;
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

        //private readonly IHttpClientFactory _httpClient;
        //public EmployeeController(IHttpClientFactory httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync("https://localhost:44363/api/Default");
                var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                var values = JsonConvert.DeserializeObject<List<EmployeeVM>>(jsonString); //listelerken

                return View(values);
            }
        }


        public IActionResult AddEmployee()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeVM employee)
        {
            using (var client = new HttpClient())
            {
                var jsonEmployee = JsonConvert.SerializeObject(employee); //eklersen 
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44363/api/Default", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync("https://localhost:44363/api/Default/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<EmployeeVM>(jsonEmployee);
                    return View(value);
                }
                return RedirectToAction("Index");

            }


        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeVM employee)
        {

            using (var httpClient = new HttpClient())
            {
                var value = JsonConvert.SerializeObject(employee);
                var content = new StringContent(value, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:44363/api/Default/", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(employee);
            }

        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.DeleteAsync("https://localhost:44363/api/Default/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                   
                }

                return View();
            }
        }

    }
}
