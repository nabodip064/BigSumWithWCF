using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BigSumBLL
    {
        private DatabaseAccess _dba;
        
        public BigSumBLL()
        {
            _dba = new DatabaseAccess();
        }
        public string GetAllNumberInfos(int? userId, DateTime? fromDate, DateTime? toDate)
        {
            var numberInfo = _dba.GetNumberInfo(userId, fromDate, toDate);

            return numberInfo;
        }
        public string GetAllUsers()
        {
            return _dba.GetAllUsers();
        }
        public string SumResultOfTwoNumbers(string number1, string number2, string userName)
        {
            var numberInfo = new NuberInfo();
            numberInfo.FirstNumber = number1;
            numberInfo.SecondNumber = number2;
            numberInfo.UserId = this.GetUserName(userName);
            numberInfo.CalculationDate = DateTime.Now;
            numberInfo.SumResult = this.GetSumValue(number1, number2);
            _dba.SaveNumberInfo(numberInfo);
            return numberInfo.SumResult;
        }

        private int? GetUserName(string userName)
        {
            var existUser = _dba.GetUserByUserName(userName);
            if (existUser != null)
                return existUser.ID;
            else
            {
                var user = new User();
                user.UserName = userName;
                return _dba.SaveUser(user);
            }
        }
        private string GetSumValue(string number1, string number2)
        {
            int temp = 0;
            string result = "";
            var num1CharAr = number1.ToCharArray();
            var num2CharAr = number2.ToCharArray();
            var maxLength = this.GetMaxLength(num1CharAr, num2CharAr);
            for (int i = maxLength - 1; i >= 0; i--)
            {
                var num1 = this.GetIntValueFromCharArry(i, num1CharAr, maxLength);
                var num2 = this.GetIntValueFromCharArry(i, num2CharAr, maxLength);
                var sumNum = num1 + num2 + temp;
                var reminder = sumNum % 10;
                temp = sumNum / 10;
                result = reminder.ToString() + result;
            }
            if (temp != 0)
                result = temp.ToString() + result;
            return result;
        }
        private int GetMaxLength(char[] num1CharAr, char[] num2CharAr)
        {
            if (num2CharAr.Count() > num1CharAr.Count())
                return num2CharAr.Count();

            return num1CharAr.Count();
        }
        private int GetIntValueFromCharArry(int index, char[] numberAr, int maxLength)
        {
            var flexibleIndex = numberAr.Count() - maxLength + index;
            if (flexibleIndex >= 0)
                return numberAr[flexibleIndex] - '0';
            return 0;
        }
    }
}
