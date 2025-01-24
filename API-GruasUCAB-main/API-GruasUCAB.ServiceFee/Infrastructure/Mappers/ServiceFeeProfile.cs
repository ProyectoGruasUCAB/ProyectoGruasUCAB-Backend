namespace API_GruasUCAB.ServiceFee.Infrastructure.Mappers
{
     public class ServiceFeeProfile : Profile
     {
          public ServiceFeeProfile()
          {
               CreateMap<Domain.AggregateRoot.ServiceFee, ServiceFeeDTO>()
                   .ForMember(dest => dest.ServiceFeeId, opt => opt.MapFrom(src => src.Id.Value))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                   .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
                   .ForMember(dest => dest.PriceKm, opt => opt.MapFrom(src => src.PriceKm.Value))
                   .ForMember(dest => dest.Radius, opt => opt.MapFrom(src => src.Radius.Value))
                   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value));

               CreateMap<ServiceFeeDTO, Domain.AggregateRoot.ServiceFee>()
                   .ConstructUsing(dto => new Domain.AggregateRoot.ServiceFee(
                       new ServiceFeeId(dto.ServiceFeeId),
                       new ServiceFeeName(dto.Name),
                       new ServiceFeePrice(dto.Price),
                       new ServiceFeePriceKm(dto.PriceKm),
                       new ServiceFeeRadius(dto.Radius),
                       new ServiceFeeDescription(dto.Description)
                   ));
          }
     }
}