using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using DAL;

namespace BigSumWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private BigSumBLL _bllObj;
        public UserService()
        {
            _bllObj = new BigSumBLL();
        }
        public string GetAllNumberInfos(int? userId, DateTime? fromDate, DateTime? toDate)
        {
            var numberInfos = _bllObj.GetAllNumberInfos(userId, fromDate, toDate);
            return numberInfos;
        }

        public string GetAllUsers()
        {
            var users = _bllObj.GetAllUsers();
            return users;
        }
        public string InsertNumbers(string number1, string number2, string userName)
        {
            var sumResult = _bllObj.SumResultOfTwoNumbers(number1, number2, userName);
            return sumResult;
        }
    }
}
