namespace GPM.CubeIntersector.Domain.Profiles;

public class DomainProfile : ProfileBase
{

    #region constructors / deconstructors / destructors

    public DomainProfile()
    {
        CreateMap<ICube, CubeDto>();

        CreateMap<CubeDto, Cube>();

        CreateMap<ICube, CubeSet>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.Empty));

        CreateMap<CubeSet, Cube>();
    }

    #endregion

}
