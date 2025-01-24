namespace API_GruasUCAB.Department.Infrastructure.Mappers
{
     public class DepartmentProfile : Profile
     {
          public DepartmentProfile()
          {
               CreateMap<Domain.AggregateRoot.Department, DepartmentDTO>()
                   .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id.Value))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                   .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description.Value));

               CreateMap<DepartmentDTO, Domain.AggregateRoot.Department>()
                   .ConstructUsing(src => new Domain.AggregateRoot.Department(
                       new DepartmentId(src.DepartmentId),
                       new DepartmentName(src.Name),
                       new DepartmentDescription(src.Descripcion)));
          }
     }
}