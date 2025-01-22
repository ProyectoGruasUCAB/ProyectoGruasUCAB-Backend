namespace API_GruasUCAB.Vehicle.Infrastructure.Mapping
{
     public class VehicleTypeProfile : Profile
     {
          public VehicleTypeProfile()
          {
               CreateMap<VehicleType, VehicleTypeDTO>()
                   .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.Id.Value))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.ToString()))
                   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.DescripcionVehicleType.Value));

               CreateMap<VehicleTypeDTO, VehicleType>()
                   .ConstructUsing(src => new VehicleType(
                       new VehicleTypeId(src.VehicleTypeId),
                       Enum.Parse<VehicleTypeEnumerate>(src.Name),
                       new DescripcionVehicleType(src.Description)
                   ));
          }
     }
}