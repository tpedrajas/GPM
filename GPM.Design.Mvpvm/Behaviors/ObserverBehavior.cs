namespace GPM.Design.Mvpvm.Behaviors;

public class ObserverBehavior : Behavior, IObserverBehavior
{

    #region constructors / deconstructors / destructors

    public ObserverBehavior() : base()
    {

    }

    #endregion

    #region properties

    private readonly Dictionary<(string TransmitterAlias, string EventName), (string TransmitterAlias, string EventName)> SubscribedChannels = new();

    #endregion

    #region methods

    protected override void OnConfiguring(object? sender, BehaviorConfiguringEventArgs e)
    {
        base.OnConfiguring(sender, e);

        var centralizer = (INotificationCentralizerBehavior)Behaviors.Single(pair => Equals(pair.Key, typeof(INotificationCentralizerBehavior))).Value;

        foreach(var element in SubscribedChannels)
        {
            centralizer.TrySubscribeChannel(element.Value, this);
        }
    }

    public virtual void OnCompleted()
    {

    }

    public virtual void OnError(Exception exception)
    {

    }

    public virtual void OnNext(IChannelNotificatorBehavior notificator)
    {

    }

    public void TryAddSubscribedChannel((string TransmistterAlias, string EventName) channel)
    {
        SubscribedChannels.TryAdd(channel, channel);
    }

    #endregion

}
