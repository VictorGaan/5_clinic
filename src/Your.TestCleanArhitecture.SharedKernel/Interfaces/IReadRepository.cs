using Ardalis.Specification;

namespace Your.TestCleanArhitecture.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
