using Ardalis.Specification;

namespace Your.TestCleanArhitecture.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
