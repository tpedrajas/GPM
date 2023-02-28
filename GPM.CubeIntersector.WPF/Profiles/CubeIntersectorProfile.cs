namespace GPM.CubeIntersector.WPF.Profiles;

public class CubeIntersectorProfile : ProductProfile
{

    #region constructors / deconstructors / destructors

    public CubeIntersectorProfile()
    {
        CreateMap<CubeDTO, Cube>()
            .ReverseMap();
    }

    #endregion

}
