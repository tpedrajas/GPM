namespace GPM.CubeIntersector.Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    #region constructors / deconstructors / destructors

    public App()
    {
        
    }

    #endregion

    #region properties

    private static IHostInitiator AppHostInitiator { get; } = new AppHostInitiator();

    #endregion

    #region methods

    protected override void OnExit(ExitEventArgs e)
    {
        AppHostInitiator.StopAsync();

        base.OnExit(e);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        CultureInfo culture = CultureInfo.GetCultureInfo(AppHostInitiator.Settings.Language);
        Thread.CurrentThread.CurrentUICulture = culture;

        AppHostInitiator.StartAsync();
    }

    #endregion

}
