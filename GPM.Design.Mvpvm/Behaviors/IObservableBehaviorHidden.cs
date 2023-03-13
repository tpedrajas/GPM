namespace GPM.Design.Mvpvm.Behaviors;

internal interface IObservableBehaviorHidden : IBehaviorHidden, INotifyPropertyChanged, IObservable<IChannelNotificatorBehavior>
{

}
