using System.Net;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions.Base;

namespace ExceptionHandlingResultPattern.Common.Exceptions;

[Serializable]
public class CreateOperationException : CustomBaseException
{
    private new const int StatusCode = (int)HttpStatusCode.BadRequest;
    private const string MessageFormat = "{0} modeli veritabanına eklenirken hata oluştu.";
    public override string Message { get; }

    public CreateOperationException(string objName, StatusTypes statusTypes) : base(StatusCode,statusTypes)
    {
        Message = string.Format(MessageFormat, objName);
    }

    public CreateOperationException(string objValue, string objName, string errorCode, StatusTypes statusTypes) : base(StatusCode, errorCode,statusTypes)
    {
        Message = string.Format(MessageFormat, objName);
    }
}