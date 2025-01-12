using API_GruasUCAB.Core.Domain.conf;

namespace API_GruasUCAB.Users.Infrastructure.EventStore
{
     public class InMemoryEventStore : IEventStore
     {
          private readonly Dictionary<string, List<IDomainEvent>> _eventStreams = new();

          public Task<List<IDomainEvent>> GetEventsByStream(string streamId)
          {
               _eventStreams.TryGetValue(streamId, out var events);
               return Task.FromResult(events ?? new List<IDomainEvent>());
          }

          public Task AppendEvents(string streamId, List<IDomainEvent> events)
          {
               if (!_eventStreams.ContainsKey(streamId))
               {
                    _eventStreams[streamId] = new List<IDomainEvent>();
               }

               _eventStreams[streamId].AddRange(events);
               return Task.CompletedTask;
          }
     }
}