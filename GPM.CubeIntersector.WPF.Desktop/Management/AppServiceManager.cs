namespace GPM.CubeIntersector.WPF.Desktop.Management;

internal class AppServiceManager : MvpvmServiceManager
{

    #region constructors / deconstructors / destructors

    public AppServiceManager() : base()
    {

    }

    #endregion

    #region methods

    protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainProfile));

        services.AddSingleton<ICubeIntersectionViewModel, CubeIntersectionViewModel>();
        services.AddSingleton<ICubeIntersectionView, CubeIntersectionView>();
        services.AddSingleton<IMvpvmMainPresenter, AppMainPresenter>();

        services.AddTransient<IAboutViewModel, AboutViewModel>();
        services.AddTransient<IAboutView, AboutView>();
        services.AddTransient<IAboutPresenter, AboutPresenter>();

        base.ConfigureServices(context, services);
    }

    #endregion

}