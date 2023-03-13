namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class ViewModelProcessorBehavior : Behavior, IViewModelProcessorBehavior
{

    #region constructors / deconstructors / destructors

    public ViewModelProcessorBehavior() : base()
    {
        
    }

    #endregion

    #region events

    public event CancelEventHandler ViewModel_Validating = delegate { };

    #endregion

    #region methods

    protected override void OnConfiguring(object? sender, BehaviorConfiguringEventArgs e)
    {
        base.OnConfiguring(sender, e);

        IViewModel viewModel = e.Presenter.GetViewModel();

        viewModel.Validating += OnViewModel_Validating;
    }

    protected override void OnUnloading(object? sender, BehaviorUnloadingEventArgs e)
    {
        base.OnUnloading(sender, e);

        IViewModel viewModel = e.Presenter.GetViewModel();

        viewModel.Validating -= OnViewModel_Validating;
    }

    #endregion

    #region viewmodel methods

    private void OnViewModel_Validating(object? sender, CancelEventArgs e)
    {
        if (!e.Cancel)
        {
            Notify((nameof(IViewModelProcessorBehavior), IViewModelProcessorBehavior.VIEWMODEL_VALIDATING_EVENT), true);

            ViewModel_Validating(sender, e);
        }
    }

    #endregion

}
