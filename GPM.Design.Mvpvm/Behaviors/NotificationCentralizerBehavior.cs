namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class NotificationCentralizerBehavior : Behavior, INotificationCentralizerBehavior, INotificationCentralizerBehaviorHidden
{

    #region constructors / deconstructors / destructors

    public NotificationCentralizerBehavior(IServiceProvider services)
    {
        Services = services;
    }

    #endregion

    #region properties

    private Dictionary<(string TransmitterAlias, string EventName), IChannelNotificatorBehavior> Channels { get; } = new();

    private IServiceProvider Services { get; init; }

    #endregion

    #region methods

    void INotificationCentralizerBehaviorHidden.CreateBehaviorChannels(IBehavior behavior)
    {
        EventInfo[] events = behavior.GetType().GetEvents(BindingFlags.Instance | BindingFlags.Public);

        if (events.Length is not 0)
        {
            foreach (EventInfo element in events)
            {
                Channels.TryAdd((behavior.Alias, element.Name), Services.GetRequiredService<IChannelNotificatorBehavior>());
            }
        }
    }

    bool INotificationCentralizerBehaviorHidden.TryNotifyChannel((string TransmitterAlias, string EventName) channel, object[] data)
    {
        bool isNotified = false;

        if (Channels.TryGetValue(channel, out IChannelNotificatorBehavior? notificator))
        {
            notificator.SetData(data);
            isNotified = true;
        }

        return isNotified;
    }

    void INotificationCentralizerBehaviorHidden.TrySubscribeChannel((string TransmitterAlias, string EventName) channel, IObserver<IChannelNotificatorBehavior> observer)
    {
        Channels[channel].Subscribe(observer);
    }

    #endregion
}
