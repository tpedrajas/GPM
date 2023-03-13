namespace GPM.Design.Mvpvm;

public class Presenter<TView, TViewModel> : IPresenter, IPresenterHidden where TView : IView where TViewModel : IViewModel
{

    #region constructors / deconstructors / destructors

    public Presenter(IServiceProvider services)
    {
        Initializing += OnInitializing;

        PresenterProcessor = services.GetRequiredService<IPresenterProcessorBehavior>();
        View = services.GetRequiredService<TView>();
        ViewModel = services.GetRequiredService<TViewModel>();
        ViewModelProcessor = services.GetRequiredService<IViewModelProcessorBehavior>();
        ViewProcessor = services.GetRequiredService<IViewProcessorBehavior>();

        View.SetDataContext(ViewModel);

        Behaviors = new Dictionary<Type, IBehavior>()
        {
            { typeof(INotificationCentralizerBehavior), services.GetRequiredService<INotificationCentralizerBehavior>() }
        };

        TryAddBehavior(PresenterProcessor);
        TryAddBehavior(ViewProcessor);
        TryAddBehavior(ViewModelProcessor);
    }

    #endregion

    #region events

    public event EventHandler Initializing = delegate { };

    public event EventHandler View_Activated = delegate { };

    public event EventHandler View_Closed = delegate { };

    public event CancelEventHandler View_Closing = delegate { };

    public event EventHandler View_Deactivated = delegate { };

    public event RoutedEventHandler View_Loaded = delegate { };

    public event CancelEventHandler ViewModel_Validating = delegate { };

    #endregion

    #region properties

    protected Dictionary<Type, IBehavior> Behaviors { get; init; }

    protected IPresenterProcessorBehavior PresenterProcessor { get; init; }

    private TView View { get; init; }

    protected TViewModel ViewModel { get; init; }

    private IViewModelProcessorBehavior ViewModelProcessor { get; init; }

    private IViewProcessorBehavior ViewProcessor { get; init; }

    #endregion

    #region methods

    protected virtual void OnInitializing(object? sender, EventArgs e)
    {
        View.Activated += View_Activated;
        View.Closed += View_Closed;
        View.Closing += View_Closing;
        View.Deactivated += View_Deactivated;
        View.Loaded += View_Loaded;

        ViewModel.Validating += ViewModel_Validating;
    }

    protected virtual void OnView_Activated(object? sender, EventArgs e)
    {
        View_Activated(sender, e);
    }

    protected virtual void OnView_Closed(object? sender, EventArgs e)
    {
        View.Activated -= View_Activated;
        View.Closed -= View_Closed;
        View.Closing -= View_Closing;
        View.Deactivated -= View_Deactivated;
        View.Loaded -= View_Loaded;

        ViewModel.Validating -= ViewModel_Validating;

        View_Closed(sender, e);
    }

    protected virtual void OnView_Closing(object? sender, CancelEventArgs e)
    {
        if (!e.Cancel)
        {
            View_Closing(sender, e);
        }
    }

    protected virtual void OnView_Deactivated(object? sender, EventArgs e)
    {
        View_Deactivated(sender, e);
    }

    protected virtual void OnView_Loaded(object? sender, RoutedEventArgs e)
    {
        View_Loaded(sender, e);
    }

    protected virtual void OnViewModel_Validating(object? sender, CancelEventArgs e)
    {
        if (!e.Cancel)
        {
            ViewModel_Validating(sender, e);
        }
    }

    protected bool TryAddBehavior<TBehavior>(TBehavior behavior) where TBehavior : IBehavior
    {
        bool isAdded = false;
        behavior.Alias ??= typeof(TBehavior).Name;

        if (!Behaviors.Any(pair => Equals(pair.Key, typeof(TBehavior)) && string.Equals(pair.Value.Alias, behavior.Alias)))
        {
            INotificationCentralizerBehavior centralizer = (INotificationCentralizerBehavior)Behaviors[typeof(INotificationCentralizerBehavior)];
            centralizer.CreateBehaviorChannels(behavior);

            Behaviors.Add(typeof(TBehavior), behavior);
            isAdded = true;
        }

        return isAdded;
    }

    #endregion

    #region IPresenterHidden methods

    Dictionary<Type, IBehavior> IPresenterHidden.GetBehaviors()
    {
        return Behaviors;
    }

    IView IPresenterHidden.GetView()
    {
        return View;
    }

    IViewModel IPresenterHidden.GetViewModel()
    {
        return ViewModel;
    }

    void IPresenterHidden.Initialize(bool isDialog, bool isMain)
    {
        foreach (IBehavior behavior in Behaviors.Values)
        {
            behavior.Configure(this);
        }

        Initializing(this, EventArgs.Empty);

        IViewProcessorBehavior viewProcessor = (IViewProcessorBehavior)Behaviors[typeof(IViewProcessorBehavior)];
        viewProcessor.ShowView(this, isDialog, isMain);
    }

    void IPresenterHidden.Unload()
    {
        foreach (IBehavior behavior in Behaviors.Values)
        {
            behavior.Unload(this);
        }
    }

    #endregion

}
