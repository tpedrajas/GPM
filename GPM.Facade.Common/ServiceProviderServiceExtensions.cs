namespace GPM.Facade.Common;

public static class ServiceProviderServiceExtensions
{

    #region extension methods

    public static T GetRequiredService<T>(this IServiceProvider services, object parameter, params object[] parameters) where T : IParameterizedService
    {
        T service = services.GetRequiredService<T>();
        return (T)service.Fill(parameter, parameters);
    }

    #endregion

}
