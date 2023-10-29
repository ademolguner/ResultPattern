using System.Net;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions.Base;
using static System.String;

namespace ExceptionHandlingResultPattern.Common.Exceptions;

[Serializable]
public class UpdateOperationException : CustomBaseException
{
    private const int StatusCode = (int)HttpStatusCode.InternalServerError;
    private const string MessageFormat = "{0} modeli veritabanında güncellenirken hata oluştu.";
    public override string Message { get; }
   
    public UpdateOperationException(string objName,StatusTypes statusTypes) : base(StatusCode,statusTypes)
    {
        Message = Format(MessageFormat, objName);
    }

    public UpdateOperationException(string objName, string errorCode,StatusTypes statusTypes) : base(StatusCode, errorCode,statusTypes)
    {
        Message = Format(MessageFormat, objName);
    }
}