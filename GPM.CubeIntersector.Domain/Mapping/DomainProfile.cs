namespace GPM.CubeIntersector.Domain.Profiles;

public class DomainProfile : MvpvmProfile
{

    #region constructors / deconstructors / destructors

    public DomainProfile()
    {
        CreateMap<CubeDto, Cube>()
            .ReverseMap();
    }

    #endregion

}
