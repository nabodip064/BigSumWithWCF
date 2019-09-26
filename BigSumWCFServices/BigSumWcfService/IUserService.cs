using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BigSumWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string InsertNumbers(string number1, string number2, string userName);

        [OperationContract]
        string GetAllNumberInfos(int? userId, DateTime? fromDate, DateTime? toDate);

        [OperationContract]
        string GetAllUsers();

        // TODO: Add your service operations here
    }
}
