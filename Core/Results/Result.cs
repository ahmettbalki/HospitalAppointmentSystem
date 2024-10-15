using System.Net;
using System.Text.Json.Serialization;
namespace Core.Results;
public class Result
{
    public List<string>? ErrorMessage { get; set; }
    [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
    [JsonIgnore] public bool IsFail => !IsSuccess;
    [JsonIgnore] public HttpStatusCode Status { get; set; }
    public static Result Success(HttpStatusCode status = HttpStatusCode.OK)
    {
        return new Result()
        {
            Status = status
        };
    }
    public static Result Fail(List<string> errorMessage,
        HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new Result()
        {
            ErrorMessage = errorMessage,
            Status = status
        };
    }
    public static Result Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new Result()
        {
            ErrorMessage = [errorMessage],
            Status = status
        };
    }
}