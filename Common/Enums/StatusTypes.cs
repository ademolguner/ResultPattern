using System.ComponentModel;

namespace ExceptionHandlingResultPattern.Common.Enums;

public enum StatusTypes
{
    [Description("Successful request")] OK=1,
    [Description("Parameter error")] PARAMETER_ERROR=2,
    [Description("Databases error")] DATABASES_ERROR=3,
    [Description("Generic error")] ERROR=4
}