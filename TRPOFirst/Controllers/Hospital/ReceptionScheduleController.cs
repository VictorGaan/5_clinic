using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Services;
using TRPOFirst.Domian;

namespace TRPOFirst.Controllers.Hospital;

public class ReceptionScheduleController : Controller
{
    private readonly IScheduleResponseService _ReceptionScheduleService;
    
    public ReceptionScheduleController(IScheduleResponseService ReceptionScheduleService)
    {
        _ReceptionScheduleService = ReceptionScheduleService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllReceptionSchedule)]
    public IActionResult GetAll()
    {
        return Ok(_ReceptionScheduleService.GetReceptionSchedule());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdateReceptionSchedule)]
    public IActionResult UpdateReceptionSchedule([FromRoute]Guid idReceptionSchedule, [FromBody] UpdateReceptionSchedule request)
    {
        var receptionSchedule = new ReceptionSchedule()
        {
            IdReceptionSchedule = idReceptionSchedule,
            StartWorkingTime = request.StartWorkingTime,
            EndWorkingTime = request.EndWorkingTime,
            DurationReception = request.DurationReception
        };

        var updated = _ReceptionScheduleService.UpdateReceptionSchedule(receptionSchedule);

        if (updated)
            return Ok(receptionSchedule);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetReceptionSchedule)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid idReceptionSchedule)
    {
        var receptionScheduleService = _ReceptionScheduleService.GetReceptionScheduleById(idReceptionSchedule);
        if (receptionScheduleService == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(receptionScheduleService);
    }

    [HttpPost(ApiRoutes.Hospital.CreateReceptionSchedule)]
    public IActionResult Create([FromBody] CreateReceptionSchedule receptionScheduleRequest)
    {
        var receptionSchedule = new ReceptionSchedule
        {
            IdReceptionSchedule = receptionScheduleRequest.IdReceptionSchedule,
            StartWorkingTime = receptionScheduleRequest.StartWorkingTime,
            EndWorkingTime = receptionScheduleRequest.EndWorkingTime,
            DurationReception = receptionScheduleRequest.DurationReception
        };

        if (receptionSchedule.IdReceptionSchedule != Guid.Empty)
            receptionSchedule.IdReceptionSchedule = Guid.NewGuid();

        _ReceptionScheduleService.GetReceptionSchedule().Add(receptionSchedule);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

        var locationUri = baseUrl + "/" +
                          ApiRoutes.Hospital.GetPacients.Replace("{idReceptionSchedule}", receptionSchedule.IdReceptionSchedule.ToString());

        var response = new ReceptionScheduleResponse()
        {
            IdReceptionSchedule = receptionScheduleRequest.IdReceptionSchedule,
            StartWorkingTime = receptionScheduleRequest.StartWorkingTime,
            EndWorkingTime = receptionScheduleRequest.EndWorkingTime,
            DurationReception = receptionScheduleRequest.DurationReception
        };

        return Created(locationUri, response);
    }
}