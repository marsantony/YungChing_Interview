using DAL.Customer.Model;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Customer
{
    public class CustomerDAL : BaseDAL
    {
        public IEnumerable<CustomerModel> Query(CustomerModel Condition = null)
        {
            Condition = Condition ?? new CustomerModel();
            using (_dbCon = new SqlConnection(this.ConnectionString))
            {
                return _dbCon.Query<CustomerModel>($@"SELECT * FROM Customers 
                                            { (!string.IsNullOrEmpty(Condition.CustomerID)
                                                    ? "WHERE CustomerID = @CustomerID" : "") }", new { CustomerID = Condition.CustomerID });
            }
        }
    }
}
