namespace GPM.Design.Mvpvm.Management;

public abstract class SettingsLoader : ISettingsLoader
{

    #region constructors / deconstructors / destructors

    protected SettingsLoader()
    {
        
    }

    #endregion

    #region properties

    public abstract string Language { get; set; }

    #endregion

}
