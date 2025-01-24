namespace API_GruasUCAB.Supplier.Infrastructure.Mappers
{
     public class SupplierProfile : Profile
     {
          public SupplierProfile()
          {
               CreateMap<SupplierDTO, Domain.AggregateRoot.Supplier>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new SupplierId(src.SupplierId)))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new SupplierName(src.Name)))
                   .ForMember(dest => dest.Type, opt => opt.MapFrom(src => new SupplierType(Enum.Parse<SupplierTypeEnum>(src.Type))));

               CreateMap<Domain.AggregateRoot.Supplier, SupplierDTO>()
                   .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.Id.Value))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                   .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Value.ToString()));
          }
     }
}