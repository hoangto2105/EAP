using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using Newtonsoft.Json;
using Lab1WebApp.Models;

namespace Lab1WebApp.Controllers
{
    public class StaffsController : Controller
    {
        private string uri = "http://localhost:53157/api/Staffs";
        private HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Staff> dataList = JsonConvert.DeserializeObject<List<Staff>>(client.GetStringAsync(uri).Result);

            return View(dataList);
           
        }

        public IActionResult Search(string name)
        {
            List<Staff> dataList = JsonConvert.DeserializeObject<List<Staff>>(client.GetStringAsync(uri).Result);

            if (string.IsNullOrEmpty(name))
            {
                return View(dataList);
            }
            else
            {
                dataList = dataList.Where(s => s.Name.ToUpper().Contains(name) || s.Name.ToLower().Contains(name)).ToList();

                return View(dataList);
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            try
            {
                var model = client.PostAsJsonAsync<Staff>(uri, staff).Result;
                if(model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Staffs");
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return View();
        }
    }
}