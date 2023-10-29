namespace ExceptionHandlingResultPattern.Application.Models.Response;

public class PastaQueryResponse:IGenericResponse
{
    public string Id { get; set; }
    public string Uuid { get; set; }
    public string Name { get; set; }
}