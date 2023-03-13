namespace GPM.Design.Mvpvm.Behaviors;

public class Behavior : IBehavior, IBehaviorHidden
{

    #region constructors / deconstructors / destructors

    protected Behavior()
    {
        Configuring += OnConfiguring;
        Unloading += OnUnloading;
    }

    #endregion

    #region events

    protected event BehaviorConfiguringEventHandler Configuring = delegate { };

    protected event BehaviorUnloadingEventHandler Unloading = delegate { };

    #endregion

    #region properties 

    public required string Alias { get; set; }

    protected Dictionary<Type, IBehavior> Behaviors { get; private set; } = new();

    #endregion

    #region methods

    public void Notify((string TransmitterAlias, string EventName) channel, params object[] data)
    {
        if (data is not null)
        {
            var centralizer = (INotificationCentralizerBehavior)Behaviors.Single(pair => Equals(pair.Key, typeof(INotificationCentralizerBehavior))).Value;
            centralizer.TryNotifyChannel(channel, data);
        }
    }

    protected virtual void OnConfiguring(object? sender, BehaviorConfiguringEventArgs e)
    {
        Behaviors = e.Presenter.GetBehaviors();
    }

    protected virtual void OnUnloading(object? sender, BehaviorUnloadingEventArgs e)
    {

    }

    #endregion

    #region IBehaviorHidden methods

    void IBehaviorHidden.Configure(IPresenter presenter)
    {
        Configuring(this, new BehaviorConfiguringEventArgs() { Presenter = presenter });
    }

    void IBehaviorHidden.Unload(IPresenter presenter)
    {
        Unloading(this, new BehaviorUnloadingEventArgs() { Presenter = presenter });
    }

    #endregion

}
