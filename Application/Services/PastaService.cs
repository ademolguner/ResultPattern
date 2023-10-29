using ExceptionHandlingResultPattern.Application.Models.Request;
using ExceptionHandlingResultPattern.Application.Models.Response;
using ExceptionHandlingResultPattern.Common.Enums;
using ExceptionHandlingResultPattern.Common.Exceptions;
using ExceptionHandlingResultPattern.Domain;
using ExceptionHandlingResultPattern.Infrastructure;
using ExceptionHandlingResultPattern.Infrastructure.Services;

namespace ExceptionHandlingResultPattern.Application.Services;

public class PastaService:IPastaService
{
    public Task<GenericResult<PastaCommandResponse>> AddedAsync(PastaCreateCommandRequest command)
    {
        if (Guid.Parse(command.Uuid) == Guid.Empty) 
            throw new InvalidParameterException(nameof(PastaCreateCommandRequest),
                                              nameof(command.Uuid), 
                                               StatusTypes.PARAMETER_ERROR);
        
        var pastaList = Pasta.GetDatabaseExampleModels();
        if (pastaList.Any(c => c.Name == command.Name))
            throw new AlreadyExistException(nameof(PastaCreateCommandRequest.Name), 
                                            nameof(command.Name), 
                                            nameof(Pasta),
                                            StatusTypes.PARAMETER_ERROR);
        
        throw new CreateOperationException(nameof(Pasta),StatusTypes.DATABASES_ERROR);
    }
    

    public Task<GenericResult<PastaCommandResponse>> UpdatedAsync(PastaUpdateCommandRequest command)
    {
        var pastaList = Pasta.GetDatabaseExampleModels();
        
        var pastaItem = pastaList.FirstOrDefault(c => c.Uuid == command.Uuid);
        if (pastaItem==null)
            throw new NotFoundException(nameof(Pasta), 
                                     nameof(command.Uuid), 
                                     nameof(command.Uuid),
                                     StatusTypes.DATABASES_ERROR);
        
        // update operation ex
        throw new UpdateOperationException(nameof(Pasta),StatusTypes.DATABASES_ERROR);
    }

    public Task<GenericResult<PastaQueryResponse>> GetAsync(PastaFindQueryRequest request)
    {
        var pastaList = Pasta.GetDatabaseExampleModels();
        
        var pastaItem = pastaList.FirstOrDefault(c => c.Id == request.Id);
        if (pastaItem==null)
            throw new NotFoundException(nameof(Pasta), 
                                     nameof(request.Id), 
                                     nameof(request.Id),
                                     StatusTypes.DATABASES_ERROR);

        var responseItem = new PastaQueryResponse
        {
            Id = pastaItem.Id, 
            Name = pastaItem.Name, 
            Uuid = pastaItem.Uuid
        };
        
        return Task.FromResult(GenericResult<PastaQueryResponse>.Success(responseItem));
    }

    public Task<GenericResult<PastaQueryResponse>> FailAsync(PastaFailQueryRequest request)
    {
        var pastaList = Pasta.GetDatabaseExampleModels();
        
        var pastaItem = pastaList.FirstOrDefault(c => c.Id == request.Id);
        if (pastaItem==null)
            throw new NotFoundException(nameof(Pasta), 
                nameof(request.Id), 
                nameof(request.Id),
                StatusTypes.DATABASES_ERROR);
        
        if(pastaItem.Name != request.Name)
            return Task.FromResult(GenericResult<PastaQueryResponse>.Fail(StatusTypes.PARAMETER_ERROR,"Name parametresi eşit değil"));
       
        var responseItem = new PastaQueryResponse
        {
            Id = pastaItem.Id, 
            Name = pastaItem.Name, 
            Uuid = pastaItem.Uuid
        };
        
        return Task.FromResult(GenericResult<PastaQueryResponse>.Success(responseItem));
    }

    public Task<GenericResult<PastaCommandResponse>> SuccessAsync(PastaCreateCommandRequest command)
    {
        var pastaList = Pasta.GetDatabaseExampleModels();
        var newItem = new Pasta {Id = "2053", Name = command.Name, Uuid = command.Uuid};
        
        pastaList.ToList().Add(newItem);

        var response = new PastaCommandResponse
        {
            Id = newItem.Id,
            Name = newItem.Name,
            Uuid = newItem.Uuid
        };
        return Task.FromResult(GenericResult<PastaCommandResponse>.Success(response));
    }
}