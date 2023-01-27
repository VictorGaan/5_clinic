using Your.TestCleanArhitecture.Core.ProjectAggregate;
using Your.TestCleanArhitecture.Core.ProjectAggregate.Specifications;
using Your.TestCleanArhitecture.SharedKernel.Interfaces;
using Your.TestCleanArhitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Your.TestCleanArhitecture.Web.Controllers;

[Route("[controller]")]
public class ProjectController : Controller
{
  private readonly IRepository<Project> _projectRepository;

  public ProjectController(IRepository<Project> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  // GET project/{projectId?}
  [HttpGet("{projectId:int}")]
  public async Task<IActionResult> Index(int projectId = 1)
  {
    var spec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _projectRepository.FirstOrDefaultAsync(spec);
    if (project == null)
    {
      return NotFound();
    }

    var dto = new ProjectViewModel
    {
      Id = project.Id,
      Name = project.FirstName,
      Items = project.Items
                    .Select(item => ToDoItemViewModel.FromToDoItem(item))
                    .ToList()
    };
    return View(dto);
  }
}
