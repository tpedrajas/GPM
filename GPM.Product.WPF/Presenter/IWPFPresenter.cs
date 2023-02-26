namespace GPM.Product.WPF.Presenter;

public interface IWPFPresenter : IPresenter
{

}

public interface IWPFPresenter<VT, VMT, SM> : IWPFPresenter, IPresenter<VT, SM> where VT : IWPFView where VMT : IWPFViewModel where SM : IWPFServiceManager
{

    #region events

    public event EventHandler ViewModelLinked; 

    #endregion

}
