using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Services;
using TRPOFirst.Domian;

namespace TRPOFirst.Controllers.Hospital;

public class ReseptionController : Controller
{
    private readonly IReceptionService _receptioService;
    
    public ReseptionController(IReceptionService receptionService)
    {
        _receptioService = receptionService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllReception)]
    public IActionResult GetAll()
    {
        return Ok(_receptioService.GetReseption());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdateReception)]
    public IActionResult UpdateReception([FromRoute]Guid IdReception, [FromBody] UpdateReseptionRequest request)
    {
        var reseption = new Reseption()
        {
            IdReception = IdReception,
            IdAppointments = request.IdAppointments,
            Complaints = request.Complaints,
            IdDisease = request.IdDisease,
            DateReception = request.DateReception
        };

        var updated = _receptioService.UpdateReseption(reseption);

        if (updated)
            return Ok(reseption);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetReception)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid IdReception)
    {
        var post = _receptioService.GetReseptionById(IdReception);
        if (post == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(post);
    }

    [HttpPost(ApiRoutes.Hospital.CreateReception)]
    public IActionResult Create([FromBody] CreateReseptionRequest receptionRequest)
    {
        var reseption = new Reseption
        {
            IdReception = receptionRequest.IdReception,
            IdAppointments = receptionRequest.IdAppointments,
            Complaints = receptionRequest.Complaints,
            IdDisease = receptionRequest.IdDisease,
            DateReception = receptionRequest.DateReception
        };

        if (reseption.IdReception != Guid.Empty)
            reseption.IdReception = Guid.NewGuid();

        _receptioService.GetReseption().Add(reseption);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

        var locationUri = baseUrl + "/" +
                          ApiRoutes.Hospital.GetPacients.Replace("{IdReception}", reseption.IdReception.ToString());

        var response = new ReseptionResponse()
        {
            IdReception = receptionRequest.IdReception,
            IdAppointments = receptionRequest.IdAppointments,
            Complaints = receptionRequest.Complaints,
            IdDisease = receptionRequest.IdDisease,
            DateReception = receptionRequest.DateReception
        };

        return Created(locationUri, response);
    }
}