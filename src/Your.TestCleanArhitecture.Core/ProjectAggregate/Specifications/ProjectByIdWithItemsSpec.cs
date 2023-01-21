using Ardalis.Specification;
using Your.TestCleanArhitecture.Core.ProjectAggregate;

namespace Your.TestCleanArhitecture.Core.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}
