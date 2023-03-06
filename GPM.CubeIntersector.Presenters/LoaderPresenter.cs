namespace GPM.CubeIntersector.Presenters;

public class LoaderPresenter : Presenter<ILoaderView, ILoaderViewModel>, ILoaderPresenter
{

    #region constructors / deconstructors / destructors

    public LoaderPresenter(IServiceProvider services) : base(services)
    {

    }

    #endregion

}
