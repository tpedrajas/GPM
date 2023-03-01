namespace GPM.Design.Abstractions.Management;

public interface IServiceManagerBase : IAsyncDisposable
{

    #region properties

    public IHost? Hosting { get; }

    public IServiceProvider ServiceProvider { get; }

    #endregion

    #region methods
    public void Run();

    #endregion

}
