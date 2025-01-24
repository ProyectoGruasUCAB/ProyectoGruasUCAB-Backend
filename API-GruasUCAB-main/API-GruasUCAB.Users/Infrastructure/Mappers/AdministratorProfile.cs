namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public class AdministratorProfile : Profile
     {
          public AdministratorProfile()
          {
               CreateMap<Administrator, AdministratorDTO>()
                   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id.Id))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                   .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
                   .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula.Value))
                   .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Value.ToString("dd-MM-yyyy")));
          }
     }
}