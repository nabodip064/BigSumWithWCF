using BigNumberSum.Model;
using BigNumberSum.ServiceReference1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BigNumberSum.Controllers
{
    public class NumberInfoController : Controller
    {
        private ServiceReference1.UserServiceClient _client;

        public NumberInfoController()
        {
            _client = new ServiceReference1.UserServiceClient("BasicHttpBinding_IUserService");
        }
        // GET: NumberInfo
        public ActionResult Index(int? userId, DateTime? fromDate, DateTime? toDate)
        {
            var userList = new List<UserViewModel>();
            var numberList = new List<NumberInfoViewModel>();
            var duserList = JsonConvert.DeserializeObject<dynamic>(_client.GetAllUsers());
            var dnumberInfo = JsonConvert.DeserializeObject<dynamic>(_client.GetAllNumberInfos(userId, fromDate, toDate));

            foreach(var item in duserList)
            {
                var user = new UserViewModel();
                user.ID = item.ID;
                user.UserName = item.UserName;
                userList.Add(user);
            }
            foreach (var item in dnumberInfo)
            {
                var num = new NumberInfoViewModel();
                num.ID = item.ID;
                num.UserName = item.UserName;
                num.Number1 = item.Number1;
                num.Number2 = item.Number2;
                num.SumResult = item.SumResult;
                num.CalculationDate = item.CalculationDate;
                numberList.Add(num);
            }

            ViewBag.UserList = userList;
            return View(numberList);
        }
    }
}