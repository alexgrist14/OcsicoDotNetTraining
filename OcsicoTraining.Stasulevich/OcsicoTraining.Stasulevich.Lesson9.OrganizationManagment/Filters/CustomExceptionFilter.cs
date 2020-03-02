using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var exceptionStack = context.Exception.StackTrace;
            var exceptionMessage = context.Exception.Message;

            context.Result = new ContentResult
            {
                Content = $"In method {actionName} throws exception: \n {exceptionMessage} \n {exceptionStack}"
            };
            context.ExceptionHandled = true;
        }
    }
}
