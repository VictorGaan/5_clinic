using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Services;
using TRPOFirst.Domian;
 
namespace TRPOFirst.Controllers.Hospital;

public class DoctorsInfoController : Controller
{
    private readonly IDoctorsInfoService _doctorsInfoService;
    
    public DoctorsInfoController(IDoctorsInfoService doctorsInfo)
    {
        _doctorsInfoService = doctorsInfo;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllDoctorsInfo)]
    public IActionResult GetAll()
    {
        return Ok(_doctorsInfoService.GetDoctorsInfo());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdateDoctorsInfo)]
    public IActionResult UpdateDoctorsInfo([FromRoute]Guid idDoctorsInfo, [FromBody] UpdateDoctorsInfoRequest request)
    {
        var doctorsInf = new DoctorsInfo()
        {
            IdDoctorsInfo = idDoctorsInfo,
            ReceptionTime = request.ReceptionTime
        };

        var updated = _doctorsInfoService.UpdateDoctorsInfo(doctorsInf);

        if (updated)
            return Ok(doctorsInf);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetDoctorsInfo)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid idDoctorsInfo)
    {
        var post = _doctorsInfoService.GetDoctorsInfoById(idDoctorsInfo);
        if (post == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(post);
    }

    [HttpPost(ApiRoutes.Hospital.CreateDoctorsInfo)]
    public IActionResult Create([FromBody] CreateDoctorsInfoRequest doctorsInfoRequest)
    {
        var doctorsInfo = new DoctorsInfo
        {
            IdDoctorsInfo = doctorsInfoRequest.IdDoctorsInfo,
            ReceptionTime = doctorsInfoRequest.ReceptionTime
        };

        if (doctorsInfo.IdDoctorsInfo != Guid.Empty)
            doctorsInfo.IdDoctorsInfo = Guid.NewGuid();

        _doctorsInfoService.GetDoctorsInfo().Add(doctorsInfo);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

        var locationUri = baseUrl + "/" +
                          ApiRoutes.Hospital.GetPacients.Replace("{idDoctorsInfo}", doctorsInfo.IdDoctorsInfo.ToString());

        var response = new DoctorsInfoResponse()
        {
            IdDoctorsInfo = doctorsInfoRequest.IdDoctorsInfo,
            ReceptionTime = doctorsInfoRequest.ReceptionTime
        };

        return Created(locationUri, response);
    }
}