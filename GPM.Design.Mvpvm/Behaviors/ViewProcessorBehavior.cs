namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class ViewProcessorBehavior : Behavior, IViewProcessorBehavior, IViewProcessorBehaviorHidden
{

    #region properties

    internal required IView View { get; set; }

    #endregion

    #region events

    public event EventHandler View_Activated = delegate { };

    public event EventHandler View_Closed = delegate { };

    public event CancelEventHandler View_Closing = delegate { };

    public event EventHandler View_Deactivated = delegate { };

    public event RoutedEventHandler View_Loaded = delegate { };

    #endregion

    #region methods

    void IViewProcessorBehaviorHidden.CloseView()
    {
        View.Close();
    }

    public override IParameterizedService Fill(object parameter, params object[] parameters)
    {
        View = (IView)parameters[1];

        return base.Fill(parameter, parameters);
    }

    private void MakeMainView()
    {
        View.MakeMainView();
    }

    protected override void OnConfiguring(object? sender, EventArgs e)
    {
        base.OnConfiguring(sender, e);

        View.Activated += OnView_Activated;
        View.Closing += OnView_Closing;
        View.Closed += OnView_Closed;
        View.Deactivated += OnView_Deactivated;
        View.Loaded += OnView_Loaded;
    }

    protected override void OnUnloading(object? sender, EventArgs e)
    {
        base.OnUnloading(sender, e);

        View.Activated -= OnView_Activated;
        View.Closed -= OnView_Closed;
        View.Closing -= OnView_Closing;
        View.Deactivated -= OnView_Deactivated;
        View.Loaded -= OnView_Loaded;
    }

    void IViewProcessorBehaviorHidden.ShowView(bool isDialog, bool isMain)
    {
        ShowView(isDialog);

        if (isMain)
        {
            MakeMainView();
        }
    }

    private void ShowView(bool isDialog)
    {
        if (isDialog)
        {
            View.ShowDialog();
        }
        else
        {
            View.Show();
        }
    }

    #endregion

    #region view methods

    private void OnView_Activated(object? sender, EventArgs e)
    {
        Notify((nameof(IViewProcessorBehavior), IViewProcessorBehavior.VIEW_ACTIVATED_EVENT), true);

        View_Activated(sender, e);
    }

    private void OnView_Closed(object? sender, EventArgs e)
    {
        Notify((nameof(IViewProcessorBehavior), IViewProcessorBehavior.VIEW_CLOSED_EVENT), true);

        View_Closed(sender, e);
    }

    private void OnView_Closing(object? sender, CancelEventArgs e)
    {
        if (!e.Cancel)
        {
            Notify((nameof(IViewProcessorBehavior), IViewProcessorBehavior.VIEW_CLOSING_EVENT), true);

            if (!e.Cancel)
            {
                View_Closing(sender, e);
            }
        }
    }

    private void OnView_Deactivated(object? sender, EventArgs e)
    {
        Notify((nameof(IViewProcessorBehavior), IViewProcessorBehavior.VIEW_DEACTIVATED_EVENT), true);

        View_Deactivated(sender, e);
    }

    private void OnView_Loaded(object? sender, RoutedEventArgs e)
    {
        Notify((nameof(IViewProcessorBehavior), IViewProcessorBehavior.VIEW_LOADED_EVENT), true);

        View_Loaded(sender, e);
    }

    #endregion

}
