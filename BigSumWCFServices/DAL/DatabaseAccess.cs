using DAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseAccess
    {
        private BigSumDBEntities1 _db;
        public DatabaseAccess()
        {
            _db = new BigSumDBEntities1();
        }
        public void SaveNumberInfo(NuberInfo numInfo)
        {
            _db.NuberInfos.Add(numInfo);
            _db.SaveChanges();
        }
        public int SaveUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.ID;
        }
        public User GetUserByUserName(string userName)
        {
            var user = _db.Users.Where(m => m.UserName == userName).FirstOrDefault();
            return user;
        }
        public string GetAllUsers()
        {
            var db_user_list = _db.Users.ToList();
            var userList = new List<UserModel>();
            foreach(var db_user in db_user_list)
            {
                var user = new UserModel();
                user.ID = db_user.ID;
                user.UserName = db_user.UserName;
                userList.Add(user);
            }
            var jsonUser = JsonConvert.SerializeObject(userList, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                });
            return jsonUser;
        }
        public string GetNumberInfo(int? userId, DateTime? fromDate, DateTime? toDate)
        {
            var numberInfo = _db.NuberInfos.
                Where(m => m.UserId == userId || userId == null).
                Where(m => m.CalculationDate >= fromDate || fromDate == null).
                Where(m => m.CalculationDate <= toDate || toDate == null).
                ToList();

            var numberList = new List<NumberInfoModel>();

            foreach(var num in numberInfo)
            {
                var number = new NumberInfoModel();
                number.ID = num.ID;
                number.Number1 = num.FirstNumber;
                number.Number2 = num.SecondNumber;
                number.SumResult = num.SumResult;
                number.UserName = num.User.UserName;
                number.CalculationDate = num.CalculationDate;
                numberList.Add(number);
            }

            var jsonData = JsonConvert.SerializeObject(numberList, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                });
            return jsonData;
        }
    }
}
