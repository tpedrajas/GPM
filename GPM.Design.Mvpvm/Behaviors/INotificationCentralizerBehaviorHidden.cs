namespace GPM.Design.Mvpvm.Behaviors;

internal interface INotificationCentralizerBehaviorHidden : IBehaviorHidden
{

    #region methods

    void CreateBehaviorChannels(IBehavior behavior);

    bool TryNotifyChannel((string TransmitterAlias, string EventName) channel, object[] data);

    void TrySubscribeChannel((string TransmitterAlias, string EventName) channel, IObserver<IChannelNotificatorBehavior> observer);

    #endregion methods

}
