namespace GPM.CubeIntersector.Desktop.Management;

internal class AppSettingsLoader : SettingsLoader
{

    #region constructors / deconstructors / destructors

    public AppSettingsLoader() : base()
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
