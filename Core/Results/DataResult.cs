using System.Net;
using System.Text.Json.Serialization;
namespace Core.Results;
public class DataResult<T>
{
    public T? Data { get; set; }
    public List<string>? ErrorMessage { get; set; }
    [JsonIgnore]public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
    [JsonIgnore] public bool IsFail => !IsSuccess;
    [JsonIgnore] public HttpStatusCode Status { get; set; }
    [JsonIgnore] public string? UrlAsCreated { get; set; }
    public static DataResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new DataResult<T>()
        {
            Data = data,
            Status = status
        };
    }
    public static DataResult<T> SuccessAsCreated(T data, string urlAsCreated)
    {
        return new DataResult<T>()
        {
            Data = data,
            Status = HttpStatusCode.Created,
            UrlAsCreated = urlAsCreated
        };
    }
    public static DataResult<T> Fail(List<string> errorMessage,
        HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new DataResult<T>()
        {
            ErrorMessage = errorMessage,
            Status = status
        };
    }
    public static DataResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new DataResult<T>()
        {
            ErrorMessage = [errorMessage],
            Status = status
        };
    }
}