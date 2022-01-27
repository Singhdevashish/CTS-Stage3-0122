using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_CRUD.Filters
{
    public class MyCustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<MyCustomExceptionFilter> logger;
        public MyCustomExceptionFilter(ILogger<MyCustomExceptionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            logger.LogError("EXCEPTION OCCURED IN CODE");
            var message = context.Exception.Message;
            var stacktrace = context.Exception.StackTrace;
            var innerException = context.Exception.InnerException;
            logger.LogError(message);
            logger.LogError(stacktrace);

            if(context.Exception is ArgumentException)
            {
                var view = new ViewResult { ViewName = "Error1" };
                context.Result = view;
            }
            else if(context.Exception is NotImplementedException)
            {
                var view = new ViewResult { ViewName = "Error2" };
                context.Result = view;
            }
        }
    }
}
