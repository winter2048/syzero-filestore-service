using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using SyZero.Application.Routing;
using SyZero.FileStore.Web.Core.Models;

namespace SyZero.FileStore.Web.Core.Filter
{
    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class AppResultFilter : IResultFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;


        public void OnResultExecuted(ResultExecutedContext context)
        {
            // context.Result 
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result.GetType() == typeof(ObjectResult) && ((ObjectResult)context.Result).Value.GetType() == typeof(AppFileStreamResult))
            {
                var request = (AppFileStreamResult)((ObjectResult)context.Result).Value;
                context.HttpContext.Response.Headers.Append("Content-Disposition", request.ContentDisposition);
                context.Result = new FileStreamResult(request.OpenReadStream(), request.ContentType);
            }
            else
            {
                context.Result = new JsonResult(new ResultModel((context.Result as ObjectResult)?.Value));
            }
        }
    }
}



