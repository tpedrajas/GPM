namespace GPM.Design.Mvpvm.Management;

public abstract class AbstractConfigurator : IConfigurator
{

    #region constructors / deconstructors / destructors

    protected AbstractConfigurator()
    {
        
    }

    #endregion

    #region properties

    public abstract string Language { get; set; }

    #endregion

}
