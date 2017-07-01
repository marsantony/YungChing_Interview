using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Extension
    {

        /// <summary>
        /// 將物件轉型成某一型別的物件(僅對公開之屬性、欄位值進行轉換)
        /// </summary>
        /// <typeparam name="T">欲進行轉換的型別</typeparam>
        /// <param name="obj">欲轉換的物件</param>
        /// <returns></returns>
        public static T ToType<T>(this object obj)
        {
            string jsonContent = JsonConvert.SerializeObject(obj);
            T result = JsonConvert.DeserializeObject<T>(jsonContent);

            if (result == null)
                throw new Exception(string.Format("ToType<T> 無法對「{0}」進行反序列化(JSON.NET)", typeof(T).ToString()));

            return result;
        }
    }
}
