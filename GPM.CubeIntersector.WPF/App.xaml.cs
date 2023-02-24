namespace GPM.CubeIntersector.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    #region constructors / deconstructors / destructors

    static App()
    {
        _ServiceManager = new AppServiceManager();
    }

    #endregion

    #region fields

    private static readonly IWPFServiceManager _ServiceManager;

    #endregion

    #region methods

    protected override async void OnExit(ExitEventArgs e)
    {
        await _ServiceManager.DisposeAsync().ConfigureAwait(false);
        base.OnExit(e);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _ServiceManager.Run();
    }

    #endregion

}
