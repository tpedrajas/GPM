namespace GPM.Facade.Design.Mvpvm.Behaviors;

public interface IViewModelProcessorBehavior : IBehavior
{

    #region constants

    const string VIEWMODEL_VALIDATING_EVENT = nameof(ViewModel_Validating);

    #endregion

    #region events

    event CancelEventHandler ViewModel_Validating;

    #endregion

}
