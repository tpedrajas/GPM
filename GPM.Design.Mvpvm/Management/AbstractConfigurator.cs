namespace GPM.Design.Mvpvm.Management;

public interface IConfigurator
{

    #region properties

    string Language { get; set; }

    #endregion

}

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
