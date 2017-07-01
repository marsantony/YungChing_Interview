using BLL.Order;
using Demo.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers
{
    public class OrderController : BaseApiController
    {
        OrderBLL OrderBLLObj = new OrderBLL();

        [AllowAnonymous]
        // GET: api/Order
        public IEnumerable<ViewModel.Order> Get()
        {
            return OrderBLLObj.Query<ViewModel.Order>();
        }

        [AllowAnonymous]
        // GET: api/Order/5
        public IEnumerable<ViewModel.Order> Get(int id)
        {
            return OrderBLLObj.Query<ViewModel.Order>(id);
        }

        // POST: api/Order
        public HttpResponseMessage Post([FromBody]ViewModel.Order value)
        {
            OrderBLLObj.Insert(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Order/5
        public HttpResponseMessage Put(int id, [FromBody]ViewModel.Order value)
        {
            value.OrderID = id;
            OrderBLLObj.Update(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put([FromBody]ViewModel.Order value)
        {
            OrderBLLObj.Update(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Order/5
        public HttpResponseMessage Delete(int id)
        {
            OrderBLLObj.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
