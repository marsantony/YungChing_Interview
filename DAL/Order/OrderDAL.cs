using DAL.Order.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Order
{
    public class OrderDAL : BaseDAL
    {
        public IEnumerable<OrderModel> Query(OrderModel Condition = null)
        {
            Condition = Condition ?? new OrderModel();
            using (_dbCon = new SqlConnection(this.ConnectionString))
            {
                return _dbCon.Query<OrderModel>($@"SELECT * FROM Orders 
                                            { (Condition.OrderID.HasValue
                                                    ? "WHERE OrderID = @OrderID" : "") }", new { OrderID = Condition.OrderID });
            }
        }

        public void Insert(OrderModel NewOrder)
        {
            using (_dbCon = new SqlConnection(this.ConnectionString))
            {
                _dbCon.Open();
                using (var transaction = _dbCon.BeginTransaction())
                {
                    try
                    {
                        _dbCon.Execute(@"INSERT INTO Orders VALUES
           (@CustomerID
           , @EmployeeID
           , @OrderDate
           , @RequiredDate
           , @ShippedDate
           , @ShipVia
           , @Freight
           , @ShipName
           , @ShipAddress
           , @ShipCity
           , @ShipRegion
           , @ShipPostalCode
           , @ShipCountry)", NewOrder, transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(OrderModel EditOrder)
        {
            using (_dbCon = new SqlConnection(this.ConnectionString))
            {
                _dbCon.Open();
                using (var transaction = _dbCon.BeginTransaction())
                {
                    try
                    {
                        _dbCon.Execute($@"UPDATE Orders SET { GetUpdateSet(EditOrder) } WHERE OrderID = @OrderID", EditOrder, transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(int OrderID)
        {
            using (_dbCon = new SqlConnection(this.ConnectionString))
            {
                _dbCon.Open();
                using (var transaction = _dbCon.BeginTransaction())
                {
                    try
                    {
                        _dbCon.Execute(@"DELETE FROM Orders WHERE OrderID = @OrderID", new { OrderID = OrderID }, transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }

}
