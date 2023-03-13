namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class ViewProcessorBehavior : Behavior, IViewProcessorBehavior, IViewProcessorBehaviorHidden
{

    #region constructors / deconstructors / destructors

    public ViewProcessorBehavior() : base()
    {

    }

    #endregion

    #region events

    public event EventHandler View_Activated = delegate { };

    public event EventHandler View_Closed = delegate { };

    public event CancelEventHandler View_Closing = delegate { };

    public event EventHandler View_Deactivated = delegate { };

    public event RoutedEventHandler View_Loaded = delegate { };

    #endregion

    #region methods

    void IViewProcessorBehaviorHidden.CloseView(IPresenter presenter)
    {
        IView view = presenter.GetView();
        view.Close();
    }

    private static void MakeMainView(IView view)
    {
        view.MakeMainView();
    }

    protected override void OnConfiguring(object? sender, BehaviorConfiguringEventArgs e)
    {
        base.OnConfiguring(sender, e);

        IView view = e.Presenter.GetView();

        view.Activated += OnView_Activated;
        view.Closing += OnView_Closing;
        view.Closed += OnView_Closed;
        view.Deactivated += OnView_Deactivated;
        view.Loaded += OnView_Loaded;
    }

    protected override void OnUnloading(object? sender, BehaviorUnloadingEventArgs e)
    {
        base.OnUnloading(sender, e);

        IView view = e.Presenter.GetView();

        view.Activated -= OnView_Activated;
        view.Closed -= OnView_Closed;
        view.Closing -= OnView_Closing;
        view.Deactivated -= OnView_Deactivated;
        view.Loaded -= OnView_Loaded;
    }

    void IViewProcessorBehaviorHidden.ShowView(IPresenter presenter, bool isDialog, bool isMain)
    {
        IView view = presenter.GetView();

        ShowView(view, isDialog);

        if (isMain)
        {
            MakeMainView(view);
        }
    }

    private static void ShowView(IView view, bool isDialog)
    {
        if (isDialog)
        {
            view.ShowDialog();
        }
        else
        {
            view.Show();
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

            View_Closing(sender, e);
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
