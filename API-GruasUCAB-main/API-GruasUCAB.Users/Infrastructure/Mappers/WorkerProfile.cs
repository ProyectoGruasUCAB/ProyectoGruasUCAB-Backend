namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public class WorkerProfile : Profile
     {
          public WorkerProfile()
          {
               CreateMap<Worker, WorkerDTO>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                   .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email.Value))
                   .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
                   .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula.Value))
                   .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Value.ToString("dd-MM-yyyy")))
                   .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Value))
                   .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId.Id));
          }
     }
}