using Ardalis.ApiEndpoints;
using Your.TestCleanArhitecture.Core.ProjectAggregate;
using Your.TestCleanArhitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Your.TestCleanArhitecture.Web.Endpoints.Hospital;

public class Create : EndpointBaseAsync
  .WithRequest<AddDoctorRequest>
  .WithActionResult<CreateDoctorResponse>
{
  private readonly IRepository<Project> _repository;

  public Create(IRepository<Project> repository)
  {
    _repository = repository;
  }

  [HttpPost("/AddDoctor")]
  [SwaggerOperation(
    Summary = "Creates new Doctor",
    Description = "Creates a new Doctor",
    OperationId = "Project.Create",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<CreateDoctorResponse>> HandleAsync(
    AddDoctorRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request.FirstName == null)
    {
      return BadRequest();
    }
    if (request.LastName == null)
    {
      return BadRequest();
    }
    if (request.MiddleName == null)
    {
      return BadRequest();
    }

    var newProject = new Project(request.FirstName, request.LastName, request.MiddleName, request.Post, request.ReceptionSchedule, PriorityStatus.Backlog);
    var createdItem = await _repository.AddAsync(newProject, cancellationToken);
    var response = new CreateDoctorResponse
    (
      id: createdItem.Id,
      firstName: createdItem.FirstName,
      lastName: createdItem.LastName,
      middleName: createdItem.MiddleName,
      post: createdItem.Post,
      receptionSchedule: createdItem.ReceptionSchedule
      );

    return Ok(response);
  }
}
