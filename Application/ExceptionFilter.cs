using System.Net;
using Infraestructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exceptionType = context.Exception.GetType();
        if (exceptionType == typeof(BusinessException))
        {
            HandleBusinessException(context);
        }
        else
        {
            HandleUnknownException(context);
        }

        var result = new ObjectResult(new
            {
                code = context.HttpContext.Response.StatusCode,
                message = context.Exception.Message,
            }
        );

        context.Result = result;
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        context.ExceptionHandled = true;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    }

    private void HandleBusinessException(ExceptionContext context)
    {
        var exception = (BusinessException)context.Exception;
        context.ExceptionHandled = true;
        context.HttpContext.Response.StatusCode = (int)exception.StatusCode;
    }
}