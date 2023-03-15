namespace GPM.Design.Mvpvm.Behaviors;

internal class ObservableBehavior : Behavior, IObservableBehavior
{

    #region constructors / deconstructors / destructors

    public ObservableBehavior() : base()
    {
        PropertyChanged += OnPropertyChanged;
    }

    #endregion

    #region properties

    protected bool Disposed { get; private set; }

    protected List<IObserver<IChannelNotificatorBehavior>> Observers { get; } = new();

    #endregion

    #region events

    public event PropertyChangedEventHandler? PropertyChanged = delegate { };

    #endregion

    #region methods

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (!Disposed)
        {
            if (disposing)
            {

            }

            Observers.Clear();

            Disposed = true;
        }
    }

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {

    }

    public virtual IDisposable Subscribe(IObserver<IChannelNotificatorBehavior> observer)
    {
        if (!Observers.Contains(observer))
        {
            Observers.Add(observer);
        }

        return this;
    }

    #endregion

}
