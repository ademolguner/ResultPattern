using ExceptionHandlingResultPattern.Application.Models.Request;
using ExceptionHandlingResultPattern.Application.Models.Response;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions;
using ExceptionHandlingResultPattern.Domain;
using ExceptionHandlingResultPattern.Infrastructure;
using ExceptionHandlingResultPattern.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingResultPattern.Controllers;

[ApiController]
[Route("result-pattern")]
public class StartController : ControllerBase
{

    private readonly IPastaService _pastaService;

    public StartController(IPastaService pastaService)
    {
        _pastaService = pastaService ?? throw new ArgumentNullException(nameof(pastaService));
    }

    [HttpPost("error/already-exception")]
    public async Task<IActionResult> AlreadyAsync([FromBody] PastaCreateCommandRequest command)
    {
        return Ok(await _pastaService.AddedAsync(command));
    }
    
    [HttpPost("error/invalid-parameter-exception")]
    public async  Task<IActionResult> InvalidParameterAsync([FromBody] PastaCreateCommandRequest command)
    {
        return Ok(await _pastaService.AddedAsync(command));
    }
    
    [HttpPost("error/create-operation-exception")]
    public async Task<IActionResult> CreateOperationAsync([FromBody] PastaCreateCommandRequest command)
    {
        return Ok(await _pastaService.AddedAsync(command));
    }
    
    [HttpPost("error/not-found-exception")]
    public async Task<IActionResult> NotFoundAsync([FromBody] PastaFindQueryRequest request)
    {
        return Ok(await _pastaService.GetAsync(request));
    }
    
    [HttpPost("error/update-operation-exception")]
    public async Task<IActionResult> UpdateOperationAsync([FromBody] PastaUpdateCommandRequest command)
    {
        return Ok(await _pastaService.UpdatedAsync(command));
    }
    
    [HttpPost("fail")]
    public async Task<IActionResult> FailAsync([FromBody] PastaFailQueryRequest request)
    {
        return Ok(await _pastaService.FailAsync(request));
    }
    
    [HttpPost("success")]
    public async Task<IActionResult> SuccessAsync([FromBody] PastaCreateCommandRequest command)
    {
        return Ok(await _pastaService.SuccessAsync(command));
    }
}