namespace API_GruasUCAB.Core.Domain.AggregateRoot
{
     public abstract class AggregateRoot<T> : Entity<T> where T : ValueObject<T>
     {
          private readonly List<IDomainEvent> _events;

          protected AggregateRoot(T id) : base(id)
          {
               _events = new List<IDomainEvent>();
          }

          protected abstract void ValidateState();

          public IReadOnlyList<IDomainEvent> GetEvents()
          {
               return _events.AsReadOnly();
          }

          public void ClearEvents()
          {
               _events.Clear();
          }

          protected void Apply(IDomainEvent domainEvent, bool fromHistory = false)
          {
               ValidateState();

               if (!fromHistory)
               {
                    _events.Add(domainEvent);
               }
          }

          protected void Hydrate(IEnumerable<IDomainEvent> history)
          {
               if (!history.Any())
               {
                    throw new Exception("There are no events to play");
               }

               foreach (var eventItem in history)
               {
                    Apply(eventItem, true);
               }
          }

          public void AddDomainEvent(IDomainEvent domainEvent)
          {
               if (domainEvent == null)
               {
                    throw new ArgumentNullException(nameof(domainEvent), "Domain event cannot be null.");
               }
               Apply(domainEvent);
          }

          public List<IDomainEvent> PullEvents()
          {
               var events = _events.ToList();
               _events.Clear();
               return events;
          }
     }
}