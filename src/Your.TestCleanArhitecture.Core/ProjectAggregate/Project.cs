using Ardalis.GuardClauses;
using Your.TestCleanArhitecture.Core.ProjectAggregate.Events;
using Your.TestCleanArhitecture.SharedKernel;
using Your.TestCleanArhitecture.SharedKernel.Interfaces;

namespace Your.TestCleanArhitecture.Core.ProjectAggregate;

public class Project : EntityBase, IAggregateRoot
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? MiddleName { get; set; }
  public int? Post { get; set; }
  public int? ReceptionSchedule { get; set; }

  private List<ToDoItem> _items = new List<ToDoItem>();
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  public PriorityStatus Priority { get; }

  public Project(string firstName, string lastName, string middleName, int _post, int receptionSchedule, PriorityStatus priority)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    MiddleName = Guard.Against.NullOrEmpty(middleName, nameof(middleName));
    Post = _post;
    ReceptionSchedule = receptionSchedule;
    Priority = priority;
  }

  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    base.RegisterDomainEvent(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    FirstName = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
