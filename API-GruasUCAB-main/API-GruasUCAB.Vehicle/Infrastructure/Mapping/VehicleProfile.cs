using API_GruasUCAB.Vehicle.Domain.AggregateRoot;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries;
using AutoMapper;

namespace API_GruasUCAB.Vehicle.Infrastructure.Mapping
{
     public class VehicleProfile : Profile
     {
          public VehicleProfile()
          {
               CreateMap<Domain.AggregateRoot.Vehicle, VehicleDTO>()
                   .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Id.Value))
                   .ForMember(dest => dest.CivilLiability, opt => opt.MapFrom(src => src.CivilLiability.Value))
                   .ForMember(dest => dest.CivilLiabilityExpirationDate, opt => opt.MapFrom(src => src.CivilLiabilityExpirationDate.Value.ToString("dd-MM-yyyy")))
                   .ForMember(dest => dest.TrafficLicense, opt => opt.MapFrom(src => src.TrafficLicense.Value))
                   .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.LicensePlate.Value))
                   .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Value))
                   .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Value))
                   .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Value))
                   .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId.Value))
                   .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.DriverId != null ? src.DriverId.Value : (Guid?)null))
                   .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId.Value));

               CreateMap<VehicleDTO, Domain.AggregateRoot.Vehicle>()
                   .ConstructUsing(dto => new Domain.AggregateRoot.Vehicle(
                       new VehicleId(dto.VehicleId),
                       new VehicleCivilLiability(dto.CivilLiability),
                       new VehicleCivilLiabilityExpirationDate(dto.CivilLiabilityExpirationDate),
                       new VehicleTrafficLicense(dto.TrafficLicense),
                       new VehicleLicensePlate(dto.LicensePlate),
                       new VehicleBrand(dto.Brand),
                       new VehicleColor(dto.Color),
                       new VehicleModel(dto.Model),
                       new VehicleTypeId(dto.VehicleTypeId),
                       dto.DriverId != null ? new UserId(dto.DriverId.Value) : null,
                       new SupplierId(dto.SupplierId)
                   ));
          }
     }
}