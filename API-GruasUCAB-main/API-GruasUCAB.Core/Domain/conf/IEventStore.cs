namespace API_GruasUCAB.Core.Domain.conf
{
     public interface IEventStore
     {
          Task<List<IDomainEvent>> GetEventsByStream(string streamId);
          Task AppendEvents(string streamId, List<IDomainEvent> events);
     }
}