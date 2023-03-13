namespace GPM.Design.Mvpvm.Behaviors;

internal static class ObservableBehaviorExtensions
{

    #region extension methods

    internal static IDisposable Subscribe(this IObservableBehavior observable, IObserver<IChannelNotificatorBehavior> observer)
    {
        IObservableBehaviorHidden observableHidden = observable.ToObservableBehaviorHidden();
        return observableHidden.Subscribe(observer);
    }

    private static IObservableBehaviorHidden ToObservableBehaviorHidden(this IObservableBehavior observable)
    {
        return (IObservableBehaviorHidden)observable;
    }

    #endregion

}
