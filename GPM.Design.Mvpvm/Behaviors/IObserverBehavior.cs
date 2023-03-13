namespace GPM.Design.Mvpvm.Behaviors;

public interface IObserverBehavior : IBehavior, IObserver<IChannelNotificatorBehavior>
{

    #region methods

    void TryAddSubscribedChannel((string TransmistterAlias, string EventName) channel);

    #endregion

}
