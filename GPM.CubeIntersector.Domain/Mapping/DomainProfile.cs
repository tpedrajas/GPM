namespace GPM.CubeIntersector.Domain.Profiles;

public class DomainProfile : MvpvmProfile
{

    #region constructors / deconstructors / destructors

    public DomainProfile()
    {
        CreateMap<CubeDto, Cube>()
            .ReverseMap();

        CreateMap<Cube, CubeEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.Empty))
            .ReverseMap();
    }

    #endregion

}
