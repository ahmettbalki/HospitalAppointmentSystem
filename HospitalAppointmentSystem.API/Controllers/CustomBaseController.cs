using Core.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace HospitalAppointmentSystem.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]//Swagger endpoint diye algılamasın
    public IActionResult CreateActionResult<T>(DataResult<T> result)
    {
        if (result.Status == HttpStatusCode.NoContent)
        {
            return new ObjectResult(null) { StatusCode = result.Status.GetHashCode() };
        }
        return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
    }
    [NonAction]
    public IActionResult CreateActionResult(Result result)
    {
        if (result.Status == HttpStatusCode.NoContent)
        {
            return new ObjectResult(null) { StatusCode = result.Status.GetHashCode() };
        }
        return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
    }
}