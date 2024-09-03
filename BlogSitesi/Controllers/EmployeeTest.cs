using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BlogSitesi.Controllers
{
    public class EmployeeTest : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7135/api/Default");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        public IActionResult AddEmployee()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient= new HttpClient();
            var jsonEmployee=JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7135/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else { return View(p); }
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7135/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]

        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content=new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7135/api/Default/" ,content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else { return View(p); }
        }


        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7135/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }




    }


    public class Class1
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
