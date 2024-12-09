namespace API_GruasUCAB.Core.Domain.DomainEvent
{
     public interface IDomainEvent
     {
          string DispatcherId { get; }
          string Name { get; }
          DateTime Timestamp { get; }
          object? Context { get; }
     }

     public static class DomainEventFactory
     {
          public static IDomainEvent Create<T>(string name, string dispatcherId, T context)
          {
               return new DomainEventImpl<T>(dispatcherId, name, DateTime.UtcNow, context);
          }

          private class DomainEventImpl<T> : IDomainEvent
          {
               public string DispatcherId { get; private set; }
               public string Name { get; private set; }
               public DateTime Timestamp { get; private set; }
               public object? Context { get; private set; }

               public DomainEventImpl(string dispatcherId, string name, DateTime timestamp, T context)
               {
                    DispatcherId = dispatcherId ?? throw new ArgumentNullException(nameof(dispatcherId), "DispatcherId cannot be null.");
                    Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
                    Timestamp = timestamp;
                    Context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null.");
               }
          }
     }
}