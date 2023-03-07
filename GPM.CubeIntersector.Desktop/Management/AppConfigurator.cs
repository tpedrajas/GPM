namespace GPM.CubeIntersector.Desktop.Management;

internal class AppConfigurator : Configurator
{

    #region constructors / deconstructors / destructors

    public AppConfigurator() : base()
    {
        
    }

    #endregion

    #region properties

    public override string Language
    {
        get
        {
            return Settings.Language;
        }
        set
        {
            Settings.Language = value;
            Settings.Save();
        }
    }

    private AppSettings Settings { get; } = AppSettings.Default;

    #endregion

}
