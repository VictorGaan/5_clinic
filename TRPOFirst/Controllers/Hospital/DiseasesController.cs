using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Services;
using TRPOFirst.Domian;

namespace TRPOFirst.Controllers.Hospital;

public class DiseasesController : Controller
{
    private readonly IDiseasesService _diseasesService;
    
    public DiseasesController(IDiseasesService diseasesService)
    {
        _diseasesService = diseasesService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllDiseases)]
    public IActionResult GetAll()
    {
        return Ok(_diseasesService.GetDiseases());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdateDiseases)]
    public IActionResult UpdateDiseases([FromRoute]Guid IdDiseases, [FromBody] UpdateDiseasesRequest request)
    {
        var diseases = new Diseases()
        {
            IdDiseases = IdDiseases,
            Title = request.Title,
            Code = request.Code,
            Discription = request.Discription
        };

        var updated = _diseasesService.UpdateDiseases(diseases);

        if (updated)
            return Ok(diseases);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetDiseases)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid IdDiseases)
    {
        var post = _diseasesService.GetDiseasesById(IdDiseases);
        if (post == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(post);
    }

    [HttpPost(ApiRoutes.Hospital.CreateDiseases)]
    public IActionResult Create([FromBody] CreateDiseasesRequest diseasesRequest)
    {
        var diseases = new Diseases()
        {
            IdDiseases = diseasesRequest.IdDiseases,
            Title = diseasesRequest.Title,
            Code = diseasesRequest.Code,
            Discription = diseasesRequest.Discription
        };

        if (diseases.IdDiseases != Guid.Empty)
            diseases.IdDiseases = Guid.NewGuid();

        _diseasesService.GetDiseases().Add(diseases);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

        var locationUri = baseUrl + "/" +
                          ApiRoutes.Hospital.GetPacients.Replace("{IdDiseases}", diseases.IdDiseases.ToString());

        var response = new DiseasesResponse()
        {
            IdDiseases = diseasesRequest.IdDiseases,
            Title = diseasesRequest.Title,
            Code = diseasesRequest.Code,
            Discription = diseasesRequest.Discription
        };

        return Created(locationUri, response);
    }
}