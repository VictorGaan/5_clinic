using Ardalis.Result;
using Your.TestCleanArhitecture.Core.ContributorAggregate;
using Your.TestCleanArhitecture.Core.ContributorAggregate.Events;
using Your.TestCleanArhitecture.Core.Interfaces;
using Your.TestCleanArhitecture.SharedKernel.Interfaces;
using MediatR;

namespace Your.TestCleanArhitecture.Core.Services;

public class DeleteContributorService : IDeleteContributorService
{
  private readonly IRepository<Contributor> _repository;
  private readonly IMediator _mediator;

  public DeleteContributorService(IRepository<Contributor> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeleteContributor(int contributorId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ContributorDeletedEvent(contributorId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
