namespace GPM.Design.Mvpvm.Behaviors;

internal static class NotificationCentralizerBehaviorExtensions
{

    #region extension methods

    internal static void CreateBehaviorChannels(this INotificationCentralizerBehavior centralizer, IBehavior behavior)
    {
        INotificationCentralizerBehaviorHidden centralizerHidden = centralizer.ToNotificationCentralizerBehaviorHidden();
        centralizerHidden.CreateBehaviorChannels(behavior);
    }

    private static INotificationCentralizerBehaviorHidden ToNotificationCentralizerBehaviorHidden(this INotificationCentralizerBehavior centralizer)
    {
        return (INotificationCentralizerBehaviorHidden)centralizer;
    }

    internal static bool TryNotifyChannel(this INotificationCentralizerBehavior centralizer, (string TransmitterAlias, string EventName) channel, object[] data)
    {
        INotificationCentralizerBehaviorHidden centralizerHidden = centralizer.ToNotificationCentralizerBehaviorHidden();
        return centralizerHidden.TryNotifyChannel(channel, data);
    }

    internal static void TrySubscribeChannel(this INotificationCentralizerBehavior centralizer, (string TransmitterAlias, string EventName) channel, IObserver<IChannelNotificatorBehavior> observer)
    {
        INotificationCentralizerBehaviorHidden centralizerHidden = centralizer.ToNotificationCentralizerBehaviorHidden();
        centralizerHidden.TrySubscribeChannel(channel, observer);
    }

    #endregion

}
