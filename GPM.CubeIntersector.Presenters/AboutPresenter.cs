namespace GPM.CubeIntersector.Presenters;

public class AboutPresenter : Presenter<IAboutView, IAboutViewModel>, IAboutPresenter
{

    #region constructors / deconstructors / destructors

    public AboutPresenter(IServiceProvider services) : base(services)
    {
        
    }

    #endregion

}
