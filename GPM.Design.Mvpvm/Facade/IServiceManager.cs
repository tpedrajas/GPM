namespace GPM.Design.Mvpvm.Management;

public interface IServiceManager : IAsyncDisposable
{

    #region properties

    public IHost? Hosting { get; }

    public IServiceProvider ServiceProvider { get; }

    public Dictionary<string, string> Settings { get; }

    #endregion

    #region methods
    public ValueTask Run();

    #endregion

}
