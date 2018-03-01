using Microsoft.AspNetCore.Mvc;
using System;
using CubeHelper.Models;

namespace CubeHelper.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
