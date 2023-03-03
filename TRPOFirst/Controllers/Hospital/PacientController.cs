using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Domian;
using TRPOFirst.Services;

namespace TRPOFirst.Controllers.Hospital;

public class PacientController : Controller
{
    private readonly IPacientService _pacientService;
    
    public PacientController(IPacientService pacientService)
    {
        _pacientService = pacientService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllPacients)]
    public IActionResult GetAll()
    {
        return Ok(_pacientService.GetPacient());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdatePacients)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult UpdatePacients([FromRoute]Guid IdPacient, [FromBody] UpdatePacientRequest request)
    {
        var pacient = new Pacients()
        {
            IdPacient = IdPacient,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            Age = request.Age,
            Polis = request.Polis
        };

        var updated = _pacientService.UpdatePacient(pacient);

        if (updated)
            return Ok(pacient);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetPacients)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid IdPacient)
    {
        var pacient = _pacientService.GetPacientById(IdPacient);
        if (pacient == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(pacient);
    }
    
    [HttpPost(ApiRoutes.Hospital.CreatePacients)]
    public IActionResult Create([FromBody] CreatePaceintRequest pacientRequest)
    {
        var pacient = new Pacients
        {
            IdPacient = pacientRequest.IdPacient,
            FirstName = pacientRequest.FirstName,
            LastName = pacientRequest.LastName,
            MiddleName = pacientRequest.MiddleName,
            Age = pacientRequest.Age,
            Polis = pacientRequest.Polis
        };
        
        if (pacient.IdPacient != Guid.Empty)
            pacient.IdPacient = Guid.NewGuid();
        
        _pacientService.GetPacient().Add(pacient);
    
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
    
        var locationUri = baseUrl + "/" + ApiRoutes.Hospital.GetPacients.Replace("{IdPacient}", pacient.IdPacient.ToString());
        
        var response = new PacientResponse
        {
            IdPacient = pacientRequest.IdPacient,
            FirstName = pacientRequest.FirstName,
            LastName = pacientRequest.LastName,
            MiddleName = pacientRequest.MiddleName,
            Age = pacientRequest.Age,
            Polis = pacientRequest.Polis
        };
        
        return Created(locationUri, response);
    }
}