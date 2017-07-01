using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Demo.Filters
{
    /// <summary>
    /// 簡單 例外處理
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SimpleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var request = actionExecutedContext.ActionContext.Request;

            var exception = actionExecutedContext.Exception;
            //抓取所有的Exception，只把Message傳回
            actionExecutedContext.Response = request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = exception.Message });
        }
    }
}