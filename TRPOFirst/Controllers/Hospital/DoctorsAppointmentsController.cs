using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Services;
using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Controllers.Hospital;

public class DoctorsAppointmentsController : Controller
{
    private readonly IDoctorsAppointmentsService _appointmentService;
    
    public DoctorsAppointmentsController(IDoctorsAppointmentsService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllDoctorsAppointments)]
    public IActionResult GetAllDoctorsAppointments()
    {
        return Ok(_appointmentService.GetDoctorsAppointments());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdateDoctorsAppointments)]
    public IActionResult UpdateDoctorsAppointments([FromRoute]Guid idDoctorsAppointments, [FromBody] UpdateDoctorsAppointment request)
    {
        var doctorsAppointments = new DoctorsAppointments
        {
            idDoctorsAppointments = idDoctorsAppointments,
            IdDoctor = request.idDoctor,
            IdPatient = request.IdPatient,
            DateRecording = request.DateRecording
        };

        var updated = _appointmentService.UpdateDoctorsAppointments(doctorsAppointments);

        if (updated)
            return Ok(doctorsAppointments);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetDoctorsAppointments)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid idDoctorsAppointments)
    {
        var doctorsAppointments = _appointmentService.GetDoctorsAppointmentsById(idDoctorsAppointments);
        if (doctorsAppointments == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(doctorsAppointments);
    }
    
    [HttpPost(ApiRoutes.Hospital.CreateDoctorsAppointments)]
    public IActionResult Create([FromBody] CreateDoctorsAppointment doctorsAppointmentsRequest)
    {
        var doctorsAppointments = new DoctorsAppointments()
        {
            IdDoctor = doctorsAppointmentsRequest.IdDoctor,
            idDoctorsAppointments = doctorsAppointmentsRequest.idDoctorsAppointments,
            IdPatient = doctorsAppointmentsRequest.IdPatient,
            DateRecording = doctorsAppointmentsRequest.DateRecording
            
        };
        
        if (doctorsAppointments.idDoctorsAppointments != Guid.Empty)
            doctorsAppointments.idDoctorsAppointments = Guid.NewGuid();
        
        _appointmentService.GetDoctorsAppointments().Add(doctorsAppointments);
    
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
    
        var locationUri = baseUrl + "/" + ApiRoutes.Hospital.GetDoctors;

        locationUri = locationUri.Replace("{idDoctorsAppointments}", doctorsAppointments.idDoctorsAppointments.ToString());
        
        var response = new DoctorsAppointmentResponse()
        {
            IdDoctor = doctorsAppointmentsRequest.IdDoctor,
            idDoctorsAppointments = doctorsAppointmentsRequest.idDoctorsAppointments,
            IdPatient = doctorsAppointmentsRequest.IdPatient,
            DateRecording = doctorsAppointmentsRequest.DateRecording
        };
        
        return Created(locationUri, response);
    }
}