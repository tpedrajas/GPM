namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class ViewModelProcessorBehavior : Behavior, IViewModelProcessorBehavior
{

    #region properties

    internal required IViewModel ViewModel { get; set; }

    #endregion

    #region events

    public event CancelEventHandler ViewModel_Validating = delegate { };

    #endregion

    #region methods

    public override IParameterizedService Fill(object parameter, params object[] parameters)
    {
        ViewModel = (IViewModel)parameters[1];

        return base.Fill(parameter, parameters);
    }

    protected override void OnConfiguring(object? sender, EventArgs e)
    {
        base.OnConfiguring(sender, e);

        ViewModel.Validating += OnViewModel_Validating;
    }

    protected override void OnUnloading(object? sender, EventArgs e)
    {
        base.OnUnloading(sender, e);

        ViewModel.Validating -= OnViewModel_Validating;
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
