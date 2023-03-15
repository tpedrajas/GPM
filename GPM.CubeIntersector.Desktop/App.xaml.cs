namespace GPM.CubeIntersector.Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    #region properties

    private static IHostKeeper HostKeeper { get; } = new AppHostKeeper(ShutdownMode.OnMainWindowClose);

    #endregion

    #region methods

    protected async void OnExitAsync(object? sender, ExitEventArgs e)
    {
        using Task stopTask = HostKeeper.StopAsync();
        await stopTask.ConfigureAwait(false);
    }

    protected async void OnStartupAsync(object? sender, StartupEventArgs e)
    {
        CultureInfo culture = CultureInfo.GetCultureInfo(HostKeeper.Configurator.Language);
        Thread.CurrentThread.CurrentUICulture = culture;

        using Task startTask = HostKeeper.StartAsync();
        await startTask.ConfigureAwait(false);
    }

    #endregion

}
