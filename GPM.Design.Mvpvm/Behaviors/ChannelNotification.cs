namespace GPM.Design.Mvpvm.Behaviors;

public class ChannelNotification : IChannelNotification
{

    #region properties

    public bool Cancel { get; set; }

    public bool IsCancelable { get; set; }

    public int PendingBehaviors { get; set; }

    public string SourceEventName { get; set; } = string.Empty;

    public Delegate SourceMethod { get; set; } = () => { };

    //public IBehavior SourceTransmitter { get; set; } = IBehavior.Empty;

    #endregion

}
