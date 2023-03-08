using GPM.Design.Mvpvm.Extensions;

namespace GPM.Design.Mvpvm;

public interface IPresenter
{

    #region events

    event EventHandler Initialized;

    #endregion

}

internal interface IPresenterHidden
{

    #region properties

    IView View { get; }

    IViewModel ViewModel { get; }

    #endregion

    #region methods

    void Initialize();

    #endregion

}

public interface IMainPresenter : IPresenter
{

}

public class Presenter<V, VM> : IPresenter, IPresenterHidden where V : IView where VM : IViewModel
{

    #region constructors / deconstructors / destructors

    protected Presenter(IServiceProvider services)
    {
        Initialized += OnInitialized;
    
        Presentator = services.GetRequiredService<IPresentator>();
        View = services.GetRequiredService<V>();
        ViewModel = services.GetRequiredService<VM>();

        View.Activated += OnView_Activated;
        View.Closing += OnView_Closing;
        View.Closed += OnView_Closed;
        View.Deactivated += OnView_Deactivated;
        View.Loaded += OnView_Loaded;

        this.LinkDataContext();
    }

    #endregion

    #region events

    public event EventHandler Initialized = delegate { };

    #endregion

    #region properties

    protected IPresentator Presentator { get; init; }

    protected V View { get; init; }

    IView IPresenterHidden.View
    {
        get
        {
            return View;
        }
    }

    protected VM ViewModel { get; set; }

    IViewModel IPresenterHidden.ViewModel
    {
        get
        {
            return ViewModel;
        }
    }

    #endregion

    #region methods

    void IPresenterHidden.Initialize()
    {
        Initialized.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnInitialized(object? sender, EventArgs e)
    {
        Initialized -= OnInitialized;
    }

    protected virtual void OnView_Activated(object? sender, EventArgs e)
    {
        
    }

    protected virtual void OnView_Closing(object? sender, CancelEventArgs e)
    {
        Presentator.UnloadPresenter(this);
        e.Cancel = true;
    }

    protected virtual void OnView_Closed(object? sender, EventArgs e)
    {
        View.Activated -= OnView_Activated;
        View.Closed -= OnView_Closed;
        View.Closing -= OnView_Closing;
        View.Deactivated -= OnView_Deactivated;
    }

    protected virtual void OnView_Deactivated(object? sender, EventArgs e)
    {
        
    }

    protected virtual void OnView_Loaded(object? sender, RoutedEventArgs e)
    {
        View.Loaded -= OnView_Loaded;
    }

    #endregion

}
