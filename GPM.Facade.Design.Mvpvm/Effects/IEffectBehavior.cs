namespace GPM.Facade.Design.Mvpvm.Effects;

public interface IEffectBehavior : IObserverBehavior
{

    #region events

    event EventHandler Processed;

    #endregion

    #region properties

    double ChangeValue { get; set; }

    int Duration { get; set; }

    double Maximum { get; set; }

    double Minimum { get; set; }

    double Value { get; set; }

    #endregion

    #region methods

    public void Process();

    #endregion

}
