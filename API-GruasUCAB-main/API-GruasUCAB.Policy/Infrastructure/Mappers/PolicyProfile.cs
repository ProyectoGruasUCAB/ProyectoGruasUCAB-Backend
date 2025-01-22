namespace API_GruasUCAB.Policy.Infrastructure.Mappers
{
    public class PolicyProfile : Profile
    {
        public PolicyProfile()
        {
            CreateMap<Domain.AggregateRoot.Policy, PolicyDTO>()
                .ForMember(dest => dest.PolicyId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.PolicyNumber.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PolicyName.Value))
                .ForMember(dest => dest.CoverageAmount, opt => opt.MapFrom(src => src.PolicyCoverageAmount.Value))
                .ForMember(dest => dest.CoverageKm, opt => opt.MapFrom(src => src.PolicyCoverageKm.Value))
                .ForMember(dest => dest.BaseAmount, opt => opt.MapFrom(src => src.PolicyBaseAmount.Value))
                .ForMember(dest => dest.PriceKm, opt => opt.MapFrom(src => src.PolicyPriceKm.Value))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.PolicyIssueDate.Value.ToString("dd-MM-yyyy")))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.PolicyExpirationDate.Value.ToString("dd-MM-yyyy")))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.PolicyClient.Value));

            CreateMap<PolicyDTO, Domain.AggregateRoot.Policy>()
                .ConstructUsing(dto => new Domain.AggregateRoot.Policy(
                    new PolicyId(dto.PolicyId),
                    new PolicyNumber(dto.Number),
                    new PolicyName(dto.Name),
                    new PolicyCoverageAmount(dto.CoverageAmount),
                    new PolicyCoverageKm(dto.CoverageKm),
                    new PolicyBaseAmount(dto.BaseAmount),
                    new PolicyPriceKm(dto.PriceKm),
                    new PolicyIssueDate(dto.IssueDate),
                    new PolicyExpirationDate(dto.ExpirationDate, DateTime.ParseExact(dto.IssueDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                    new PolicyClient(dto.ClientId)
                ));
        }
    }
}