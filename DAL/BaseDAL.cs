using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DAL
{
    public abstract class BaseDAL
    {
        public IDbConnection _dbCon;
        public string ConnectionString { get { return WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString; } }

        public static string GetUpdateSet<T>(T Obj, IEnumerable<string> NeedUpdateColumn = null)
        {
            var Properties = Obj.GetType().GetProperties().Where(property => property.GetCustomAttribute<PrimaryKeyAttribute>(true) == null).ToList();
            if (NeedUpdateColumn != null)
                Properties = Properties.Where(property => NeedUpdateColumn.Contains(property.Name)).ToList();

            var SetList = Properties.Select(property => $"{ property.Name } = @{ property.Name }").ToList();
            return string.Join(",", SetList);
        }
    }
}
