using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form(string component, string type)
        {
            ViewData["Message"] = "Hello";
            ViewData["NumTimes"] = 12;

            string hostName = Environment.GetEnvironmentVariable("HOSTNAME_API");

            if ((component == "redis") && (type == "get"))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = httpClient.GetAsync(hostName+"/api/redis"))
                    {
                        var apiResponse = response.Result.Content.ReadAsStringAsync();

                        ViewData["Data"] = apiResponse.Result;
                    }
                }
            }
            else if ((component == "redis") && (type == "post"))
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    using (var response = httpClient.PostAsync(hostName +"/api/redis", content))
                    {
                        var apiResponse = response.Result.Content.ReadAsStringAsync();

                        ViewData["Data"] = apiResponse.Result;
                    }
                }
            }
            else if ((component == "mysql") && (type == "get"))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = httpClient.GetAsync(hostName+"/api/mysql"))
                    {
                        var apiResponse = response.Result.Content.ReadAsStringAsync();

                        ViewData["Data"] = apiResponse.Result;
                    }
                }
            }
            else if ((component == "mysql") && (type == "post"))
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    using (var response = httpClient.PostAsync(hostName+"/api/mysql", content))
                    {
                        var apiResponse = response.Result.Content.ReadAsStringAsync();

                        ViewData["Data"] = apiResponse.Result;
                    }
                }
            }


           



            return View();

        }
    }
}