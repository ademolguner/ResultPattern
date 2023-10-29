using System.Net;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions.Base;
using static System.String;

namespace ExceptionHandlingResultPattern.Common.Exceptions;

[Serializable]
public class InvalidParameterException : CustomBaseException
{
    private new const int StatusCode = (int)HttpStatusCode.BadRequest;
    private const string MessageFormat = "Geçersiz parametre. {0} : {1}";
    public override string Message { get; }
   
    public InvalidParameterException(string parameterName, 
                                     string parameterValue, 
                                     StatusTypes statusTypes) : base(StatusCode,statusTypes)
    {
        Message = Format(MessageFormat, parameterName, parameterValue);
    }

    public InvalidParameterException(string parameterName, 
                                     string parameterValue, 
                                     string errorCode, 
                                     StatusTypes statusTypes) : base(StatusCode, errorCode, statusTypes)
    {
        Message = Format(MessageFormat, parameterName, parameterValue);
    }
}