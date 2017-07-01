using BLL.Customer;
using Demo.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers
{
    public class CustomerController : BaseApiController
    {
        CustomerBLL CustomerBLLObj = new CustomerBLL();

        [AllowAnonymous]
        // GET: api/Customer
        public IEnumerable<ViewModel.Customer> Get()
        {
            return CustomerBLLObj.Query<ViewModel.Customer>();
        }

        [AllowAnonymous]
        // GET: api/Customer/5
        public IEnumerable<ViewModel.Customer> Get(string id)
        {
            return CustomerBLLObj.Query<ViewModel.Customer>(id);
        }
    }
}
