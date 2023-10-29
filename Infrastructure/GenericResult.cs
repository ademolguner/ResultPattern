#nullable enable
using System.Text.Json.Serialization;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Utilities;

namespace ExceptionHandlingResultPattern.Infrastructure;

public class GenericResult<T> where T: class, new()
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public T Data { get; private init; } = new();
    
    
    [JsonPropertyName("status")] 
    public string? Status { get; private init; }
    
    
    [JsonPropertyName("message")] 
    public string? Message { get; private init; }
    
    

    public static GenericResult<T> Success(T data)
    {
        return new GenericResult<T>
        {
            Data = data, 
            Status = StatusTypes.OK.ToString(), 
            Message = StatusTypes.OK.GetDescription()
        };
    }

    public static GenericResult<T> Fail(StatusTypes statusTypes, string? message = null)
    {
        return new GenericResult<T>
        {
            Status = statusTypes.ToString(), 
            Message = message ?? statusTypes.GetDescription()
        };
    }
    
    public static GenericResult<T> Exception(string message)
    {
        return new GenericResult<T>
        {
            Status = StatusTypes.ERROR.ToString(), 
            Message = message
        };
    }
}