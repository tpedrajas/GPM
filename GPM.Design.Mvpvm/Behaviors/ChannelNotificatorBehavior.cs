namespace GPM.Design.Mvpvm.Behaviors;

internal sealed class ChannelNotificatorBehavior : ObservableBehavior, IChannelNotificatorBehavior, IChannelNotificatorBehaviorHidden
{

    #region fields

    private object[] _Data = Array.Empty<object>();

    #endregion

    #region properties

    internal object[] Data
    {
        get
        {
            return _Data;
        }
        set
        {
            if (!Equals(_Data, value))
            {
                _Data = value;

                if (!IsCleaning)
                {
                    NotifyPropertyChanged();
                }
            }
        }
    }

    private bool IsCleaning;

    #endregion

    #region methods

    public object[] GetData()
    {
        return Data;
    }

    protected override void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(sender, e);

        if (e.PropertyName is nameof(Data))
        {
            foreach (var observer in Observers)
            {
                if (Equals(Data, Array.Empty<object>()))
                {
                    observer.OnError(new());
                }
                else
                {
                    observer.OnNext(this);
                }
            }

            IsCleaning = true;
            Data = Array.Empty<object>();
            IsCleaning = false;

            foreach (var observer in Observers)
            {
                observer.OnCompleted();
            }
        }
    }

    void IChannelNotificatorBehaviorHidden.SetData(object[] data)
    {
        Data = data;
    }

    #endregion

}
