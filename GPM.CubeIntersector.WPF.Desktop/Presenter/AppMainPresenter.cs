﻿namespace GPM.CubeIntersector.WPF.Desktop.Presenter;

internal sealed class AppMainPresenter : CubeIntersectionPresenter, IMvpvmMainPresenter
{

    #region constructors / deconstructors / destructors

    public AppMainPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IMvpvmServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {

    }

    #endregion

}