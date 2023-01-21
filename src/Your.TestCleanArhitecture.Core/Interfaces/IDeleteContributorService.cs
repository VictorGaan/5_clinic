using Ardalis.Result;

namespace Your.TestCleanArhitecture.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
