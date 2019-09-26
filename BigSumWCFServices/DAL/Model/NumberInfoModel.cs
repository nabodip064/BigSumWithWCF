using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    class NumberInfoModel
    {
        public int ID { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string SumResult { get; set; }
        public DateTime? CalculationDate { get; set; }
        public string UserName { get; set; }
    }
}
