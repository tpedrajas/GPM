namespace GPM.Facade.Design.Mvpvm.Behaviors;

public interface IChannelNotification
{

    #region properties

    bool Cancel { get; set; }

    bool IsCancelable { get; set; }

    int PendingBehaviors { get; set; }

    string SourceEventName { get; set; }

    Delegate SourceMethod { get; set; }

    //IBehavior SourceTransmitter { get; set; }

    #endregion

}
