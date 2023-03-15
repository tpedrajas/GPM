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

    protected event EventHandler Configuring = delegate { };

    protected event EventHandler Unloading = delegate { };

    #endregion

    #region properties 

    public string Alias { get; set; } = string.Empty;

    protected Dictionary<Type, IBehavior> Behaviors { get; private set; } = new();

    #endregion

    #region methods

    public virtual IParameterizedService Fill(object parameter, params object[] parameters)
    {
        Alias = (string)parameter;
        Behaviors = (Dictionary<Type, IBehavior>)parameters[0];

        return this;
    }

    public void Notify((string TransmitterAlias, string EventName) channel, params object[] data)
    {
        if (data is not null)
        {
            var centralizer = (INotificationCentralizerBehavior)Behaviors.Single(pair => Equals(pair.Key, typeof(INotificationCentralizerBehavior))).Value;
            centralizer.TryNotifyChannel(channel, data);
        }
    }

    protected virtual void OnConfiguring(object? sender, EventArgs e)
    {
        
    }

    protected virtual void OnUnloading(object? sender, EventArgs e)
    {

    }

    #endregion

    #region IBehaviorHidden methods

    void IBehaviorHidden.Configure()
    {
        Configuring(this, EventArgs.Empty);
    }

    void IBehaviorHidden.Unload()
    {
        Unloading(this, EventArgs.Empty);
    }

    #endregion

}
