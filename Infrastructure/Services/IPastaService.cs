using ExceptionHandlingResultPattern.Application.Models;
using ExceptionHandlingResultPattern.Application.Models.Request;
using ExceptionHandlingResultPattern.Application.Models.Response;

namespace ExceptionHandlingResultPattern.Infrastructure.Services;

public interface IPastaService
{
    Task<GenericResult<PastaCommandResponse>> AddedAsync(PastaCreateCommandRequest command);
    Task<GenericResult<PastaCommandResponse>> UpdatedAsync(PastaUpdateCommandRequest command);
    Task<GenericResult<PastaQueryResponse>> GetAsync(PastaFindQueryRequest request);
    Task<GenericResult<PastaQueryResponse>> FailAsync(PastaFailQueryRequest request);
    
    Task<GenericResult<PastaCommandResponse>> SuccessAsync(PastaCreateCommandRequest command);
}