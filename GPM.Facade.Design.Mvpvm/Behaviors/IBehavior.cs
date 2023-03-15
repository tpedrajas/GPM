namespace GPM.Facade.Design.Mvpvm.Behaviors;

public interface IBehavior : IParameterizedService
{

    #region properties

    string Alias { get; set; }

    #endregion

}
