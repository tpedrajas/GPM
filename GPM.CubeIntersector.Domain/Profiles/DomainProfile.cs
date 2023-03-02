namespace GPM.CubeIntersector.Domain.Profiles;

public class DomainProfile : ProfileBase
{

    #region constructors / deconstructors / destructors

    public DomainProfile()
    {
        CreateMap<CubeDto, Cube>()
            .ReverseMap();

        CreateMap<Cube, CubeSet>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.Empty))
            .ReverseMap();
    }

    #endregion

}
