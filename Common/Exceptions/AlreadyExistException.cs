using System.Net;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions.Base;
using static System.String;

namespace ExceptionHandlingResultPattern.Common.Exceptions;

[Serializable]
public class AlreadyExistException : CustomBaseException
{
    private new const int StatusCode = (int)HttpStatusCode.BadRequest;
    private const string MessageFormat = "{0} : '{1}' ile bir {2} kaydı mevcut.";
    public override string Message { get; }
    
    public AlreadyExistException(string parameterName, 
                                 string parameterValue, 
                                 string objectName,
                                 StatusTypes statusTypes) : base(StatusCode,statusTypes)
    {
        Message = Format(MessageFormat, parameterName,parameterValue,objectName);
    }

    public AlreadyExistException(string parameterName, 
                                 string parameterValue, 
                                 string objectName,
                                 string errorCode,
                                 StatusTypes statusTypes) : base(StatusCode, errorCode, statusTypes)
    {
        Message = Format(MessageFormat, parameterName,parameterValue,objectName);
    }
}