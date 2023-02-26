﻿namespace GPM.Product.WPF.ViewModel;

public interface IWPFViewModel
{

    #region events

    public event CancelEventHandler Validating;

    #endregion

    #region methods

    public void Validate();

    #endregion

}
