﻿namespace GPM.Design.Mvpvm.Management;

public class HostKeeper : IHostKeeper
{

    #region constructors / deconstructors / destructors

    protected HostKeeper(ShutdownMode shutdownMode)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        ConfigureServices(builder.Services);
        Hosting = builder.Build();

        Services = Hosting.Services;

        Presentator = Services.GetRequiredService<IPresentator>();
        Configurator = Services.GetRequiredService<IConfigurator>();
        ShutdownMode = shutdownMode;
    }

    #endregion

    #region properties

    protected bool Disposed { get; private set; }

    private IHost Hosting { get; init; }

    protected bool IsRunning { get; private set; }

    private IPresentator Presentator { get; init; }

    public IServiceProvider Services { get; init; }

    public IConfigurator Configurator { get; init; }

    private ShutdownMode ShutdownMode { get; init; }

    #endregion

    #region methods

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IPresentator, Presentator>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual async void Dispose(bool disposing)
    {
        if (!Disposed)
        {
            if (disposing)
            {
                using Task stopTask = StopAsync();
                await stopTask.ConfigureAwait(false);
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
            Presentator.LoadPresenter<IMainPresenter>(false, true);
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