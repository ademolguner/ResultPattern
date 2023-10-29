using System.Net;
using ExceptionHandlingResultPattern.Application.Models;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions.Base;
using ExceptionHandlingResultPattern.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionHandlingResultPattern.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ExceptionFilterAttribute : Attribute, IExceptionFilter
{
    private const string UnexpectedErrorMessage = "Beklenmeyen bir hata ile karşılaşıldı.";
    private const string Version = "1.0.0";

    public virtual void OnException(ExceptionContext context)
    {
        if (context.Exception is CustomBaseException baseExp)
        {
            context.HttpContext.Response.StatusCode = baseExp.StatusCode;
            context.Result = baseExp.StatusTypes== StatusTypes.ERROR
                            ? new ObjectResult(GenericResult<GenericResponse>.Exception(baseExp.Message))
                            : new ObjectResult(GenericResult<GenericResponse>.Fail(baseExp.StatusTypes,baseExp.Message));
            return;
        }
        
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new { Messages = new List<string>{UnexpectedErrorMessage}, Version });
    }
}