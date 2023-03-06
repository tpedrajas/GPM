namespace GPM.CubeIntersector.Desktop.Management;

internal class AppHostInitiator : HostInitiator
{

    #region constructors / deconstructors / destructors

    public AppHostInitiator() : base()
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainProfile));

        services.AddSingleton<ISettingsLoader, AppSettingsLoader>();

        services.AddSingleton<ICubeIntersectionViewModel, CubeIntersectionViewModel>();
        services.AddSingleton<ICubeIntersectionView, CubeIntersectionView>();
        services.AddSingleton<IMainPresenter, AppMainPresenter>();

        services.AddTransient<IAboutViewModel, AboutViewModel>();
        services.AddTransient<IAboutView, AboutView>();
        services.AddTransient<IAboutPresenter, AboutPresenter>();

        base.ConfigureServices(services);
    }

    #endregion

}
