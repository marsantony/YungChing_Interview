using DAL;
using DAL.Customer;
using DAL.Customer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BLL.Customer
{
    public class CustomerBLL
    {
        private CustomerDAL CustomerDALObj = new CustomerDAL();
        public IEnumerable<T> Query<T>(string CustomerId = null)
        {
            var ModelResult = CustomerDALObj.Query(new CustomerModel() { CustomerID = CustomerId });
            return ModelResult.ToType<IEnumerable<T>>();
        }

    }
}
