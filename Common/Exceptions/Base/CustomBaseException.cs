using ExceptionHandlingResultPattern.Common.Enums;

namespace ExceptionHandlingResultPattern.Common.Exceptions.Base;

public class CustomBaseException: Exception
{
    public string ErrorCode { get; }
    public int StatusCode { get; }
    public StatusTypes StatusTypes { get; }

    protected CustomBaseException(int statusCode,
                                  StatusTypes statusTypes)
    {
        StatusCode = statusCode;
        ErrorCode = string.Empty;
        StatusTypes = statusTypes;
    }

    protected CustomBaseException(int statusCode, 
                                  string errorCode,
                                  StatusTypes statusTypes)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        StatusTypes = statusTypes;
    }
}