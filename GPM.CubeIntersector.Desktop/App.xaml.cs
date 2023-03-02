using System.Globalization;
using System.Threading;

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

    #region fields

    private static readonly IServiceManager _ServiceManager = new AppServiceManager();

    #endregion

    #region methods

    protected override async void OnExit(ExitEventArgs e)
    {
        AppSettings.Default.Language = _ServiceManager.Settings[nameof(Language)];
        AppSettings.Default.Save();

        await _ServiceManager.DisposeAsync().ConfigureAwait(false);

        base.OnExit(e);
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _ServiceManager.Settings.Add(nameof(Language), AppSettings.Default.Language);

        CultureInfo culture = CultureInfo.GetCultureInfo(_ServiceManager.Settings[nameof(Language)]);
        Thread.CurrentThread.CurrentUICulture = culture;

        await _ServiceManager.Run().ConfigureAwait(false);
    }

    #endregion

}
