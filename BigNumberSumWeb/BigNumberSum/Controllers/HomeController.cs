using BigNumberSum.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigNumberSum.Controllers
{
    public class HomeController : Controller
    {
        private ServiceReference1.UserServiceClient _client;
        public HomeController()
        {
            _client = new ServiceReference1.UserServiceClient("BasicHttpBinding_IUserService");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public string GetResult(string userName, string number1,  string number2)
        {
            _client = new ServiceReference1.UserServiceClient("BasicHttpBinding_IUserService");
            var sumResult = _client.InsertNumbers(number1, number2, userName);
            return sumResult;
        }
    }
}