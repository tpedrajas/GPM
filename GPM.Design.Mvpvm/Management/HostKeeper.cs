namespace GPM.Design.Mvpvm.Management;

public class HostKeeper : IHostKeeper
{

    #region constructors / deconstructors / destructors

    protected HostKeeper(ShutdownMode shutdownMode)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        ConfigureServices(builder.Services);
        Hosting = builder.Build();

        Services = Hosting.Services;

        PresenterProcessor = Services.GetRequiredService<IPresenterProcessorBehavior>();
        Configurator = Services.GetRequiredService<IConfigurator>();
        ShutdownMode = shutdownMode;
    }

    #endregion

    #region properties

    protected bool Disposed { get; private set; }

    private IHost Hosting { get; init; }

    protected bool IsRunning { get; private set; }

    private IPresenterProcessorBehavior PresenterProcessor { get; init; }

    public IServiceProvider Services { get; init; }

    public IConfigurator Configurator { get; init; }

    private ShutdownMode ShutdownMode { get; init; }

    #endregion

    #region methods

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<INotificationCentralizerBehavior, NotificationCentralizerBehavior>();
        services.AddTransient<IChannelNotificatorBehavior, ChannelNotificatorBehavior>();

        services.AddSingleton<IPresenterProcessorBehavior, PresenterProcessorBehavior>();
        services.AddTransient<IViewProcessorBehavior, ViewProcessorBehavior>();
        services.AddTransient<IViewModelProcessorBehavior, ViewModelProcessorBehavior>();

        services.AddTransient<IFadeInEffectBehavior, FadeInEffectBehavior>();
        services.AddTransient<IFadeOutEffectBehavior, FadeOutEffectBehavior>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!Disposed)
        {
            if (disposing)
            {
                using Task stopTask = StopAsync();
                stopTask.Wait();
            }

            Disposed = true;
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        if (!IsRunning)
        {
            IsRunning = true;

            using Task startTask = Hosting.StartAsync(cancellationToken);
            await startTask.ConfigureAwait(false);

            Application.Current.ShutdownMode = ShutdownMode;
            PresenterProcessor.LoadPresenter<IMainPresenter>(false, true);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        if (IsRunning)
        {
            IsRunning = false;

            using Task stopTask = Hosting.StopAsync(cancellationToken);
            await stopTask.ConfigureAwait(false);
        }
    }

    #endregion

}
