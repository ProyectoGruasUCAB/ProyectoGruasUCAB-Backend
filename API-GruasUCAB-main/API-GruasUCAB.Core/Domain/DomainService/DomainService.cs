namespace API_GruasUCAB.Core.Domain.DomainService
{
     public interface IDomainService<T, R>
     {
          R Execute(T data);
     }
}