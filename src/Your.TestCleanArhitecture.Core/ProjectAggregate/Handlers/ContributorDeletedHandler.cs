﻿using Your.TestCleanArhitecture.Core.ContributorAggregate.Events;
using Your.TestCleanArhitecture.SharedKernel.Interfaces;
using Your.TestCleanArhitecture.Core.ProjectAggregate.Specifications;
using MediatR;

namespace Your.TestCleanArhitecture.Core.ProjectAggregate.Handlers;

public class ContributorDeletedHandler : INotificationHandler<ContributorDeletedEvent>
{
  private readonly IRepository<Project> _repository;

  public ContributorDeletedHandler(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectsWithItemsByContributorIdSpec(domainEvent.ContributorId);
    var projects = await _repository.ListAsync(projectSpec);
    foreach (var project in projects)
    {
      project.Items
        .Where(item => item.ContributorId == domainEvent.ContributorId)
        .ToList()
        .ForEach(item => item.RemoveContributor());
      await _repository.UpdateAsync(project);
    }
  }
}
