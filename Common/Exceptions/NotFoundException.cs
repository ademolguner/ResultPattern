using System.Net;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions.Base;
using static System.String;

namespace ExceptionHandlingResultPattern.Common.Exceptions;

[Serializable]
public  class NotFoundException : CustomBaseException
{
    private new const int StatusCode = (int)HttpStatusCode.BadRequest;
    private const string MessageFormat = "{0} kaydı bulunamadı. {1} : {2}";
    public override string Message { get; }
   
    public NotFoundException(string objectName,
                             string parameterName, 
                             string parameterValue, 
                             StatusTypes statusTypes) : base(StatusCode, statusTypes)
    {
        Message = Format(MessageFormat, objectName,  parameterName,parameterValue);
    }

    public NotFoundException(string objectName,
                             string parameterName, 
                             string parameterValue, 
                             string errorCode, 
                             StatusTypes statusTypes) : base(StatusCode, errorCode, statusTypes)
    {
        Message = Format(MessageFormat, objectName,  parameterName,parameterValue);
    }
}