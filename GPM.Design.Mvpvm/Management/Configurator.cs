namespace GPM.Design.Mvpvm.Management;

public abstract class Configurator : IConfigurator
{

    #region constructors / deconstructors / destructors

    protected Configurator()
    {
        
    }

    #endregion

    #region properties

    public abstract string Language { get; set; }

    #endregion

}
