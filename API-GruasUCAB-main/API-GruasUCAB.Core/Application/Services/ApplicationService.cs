using System.Threading.Tasks;

namespace API_GruasUCAB.Core.Application.Services
{
     public interface IService<TRequest, TResponse>
     {
          Task<TResponse> Execute(TRequest request);
     }
}