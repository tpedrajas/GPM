namespace GPM.CubeIntersector.WPF.Management;

internal class AppServiceManager : WPFServiceManager
{

    #region constructors / deconstructors / destructors

    public AppServiceManager() : base()
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<ICubeIntersectionViewModel, CubeIntersectionViewModel>();
        services.AddSingleton<ICubeIntersectionView, CubeIntersectionView>();
        services.AddSingleton<IWPFMainPresenter, AppMainPresenter>();

        services.AddTransient<IAboutViewModel, AboutViewModel>();
        services.AddTransient<IAboutView, AboutView>();
        services.AddTransient<IAboutPresenter, AboutPresenter>();

        base.ConfigureServices(context, services);
    }

    #endregion

}
