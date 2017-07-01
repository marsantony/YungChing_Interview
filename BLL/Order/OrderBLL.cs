using DAL.Order;
using DAL.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BLL.Order
{
    public class OrderBLL
    {
        private OrderDAL OrderDALObj = new OrderDAL();

        public IEnumerable<T> Query<T>(int? OrderId = null)
        {
            var ModelResult = OrderDALObj.Query(new OrderModel() { OrderID = OrderId });
            return ModelResult.ToType<IEnumerable<T>>();
        }

        public void Insert<T>(T NewOrder)
        {
            OrderDALObj.Insert(NewOrder.ToType<OrderModel>());
        }

        public void Update<T>(T EditOrder)
        {
            OrderDALObj.Update(EditOrder.ToType<OrderModel>());
        }

        public void Delete(int OrderID)
        {
            OrderDALObj.Delete(OrderID);
        }
    }
}
