using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreTempDataWithComplexDataType.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreTempDataWithComplexDataType.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PageDateTime model= new PageDateTime() { ProcessingDateTime = DateTime.Now };
            
            /*This line Create error (HTTP ERROR 500)
            Because this line try to keep complex data type in short session.
            This version of aspnetcore does not support complex datatype store in tempdata for next request.*/
            //TempData["DateTime"] = model;

            /*we can overcome this problem by using extension method.*/
            TempData.Put<PageDateTime>("DateTime", model);
            TempData.Keep("DateTime");
            return View();
        }
        public IActionResult Index1()
        {
            TempData.Keep("DateTime");
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }
    }
}
