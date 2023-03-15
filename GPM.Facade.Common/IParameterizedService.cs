namespace GPM.Facade.Common;

public interface IParameterizedService
{

    #region methods

    IParameterizedService Fill(object parameter, params object[] parameters);

    #endregion

}
