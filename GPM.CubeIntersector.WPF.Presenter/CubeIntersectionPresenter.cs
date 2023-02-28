namespace GPM.CubeIntersector.WPF.Presenter;

public class CubeIntersectionPresenter : WPFPresenter<ICubeIntersectionView, ICubeIntersectionViewModel, IWPFServiceManager>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IWPFServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        _ViewModel.AboutButtonClick += OnAboutButtonClick;
        _ViewModel.CalculateIntersectionButtonClick += OnCalculateIntersectionButtonClick;
        _ViewModel.CleanDataButtonClick += OnCleanDataButtonClick;
        _ViewModel.EnableCalculateIntersectionButtonValidating += OnEnableCalculateIntersectionButtonValidating;
        _ViewModel.EnableInformationCube1ButtonsValidating += OnEnableInformationCube1ButtonsValidating;
        _ViewModel.EnableInformationCube2ButtonsValidating += OnEnableInformationCube2ButtonsValidating;
        _ViewModel.ExistsIntersectionValidating += OnExistsIntersectionValidating;
        _ViewModel.LoadInformationCube1Click += OnLoadInformationCube1Click;
        _ViewModel.LoadInformationCube2Click += OnLoadInformationCube2Click;
        _ViewModel.SaveInformationCube1Click += OnSaveInformationCube1Click;
        _ViewModel.SaveInformationCube2Click += OnSaveInformationCube2Click;
    }

    #endregion

    #region fields

    private bool _IsCleaning;

    #endregion

    #region methods

    private void CleanInformationCube1()
    {
        _ViewModel.XPositionCube1 = string.Empty;
        _ViewModel.YPositionCube1 = string.Empty;
        _ViewModel.ZPositionCube1 = string.Empty;

        _ViewModel.WidthCube1 = string.Empty;
        _ViewModel.HeightCube1 = string.Empty;
        _ViewModel.DepthCube1 = string.Empty;
    }

    private void CleanInformationCube2()
    {
        _ViewModel.XPositionCube2 = string.Empty;
        _ViewModel.YPositionCube2 = string.Empty;
        _ViewModel.ZPositionCube2 = string.Empty;

        _ViewModel.WidthCube2 = string.Empty;
        _ViewModel.HeightCube2 = string.Empty;
        _ViewModel.DepthCube2 = string.Empty;
    }

    private void CleanInformationIntersectionCube()
    {
        _ViewModel.XPositionIntersection = null;
        _ViewModel.YPositionIntersection = null;
        _ViewModel.ZPositionIntersection = null;

        _ViewModel.WidthIntersection = null;
        _ViewModel.HeightIntersection = null;
        _ViewModel.DepthIntersection = null;
    }

    private Cube GetInformationCube1()
    {
        return new(float.Parse(_ViewModel.XPositionCube1), float.Parse(_ViewModel.YPositionCube1), float.Parse(_ViewModel.ZPositionCube1),
                   float.Parse(_ViewModel.WidthCube1), float.Parse(_ViewModel.HeightCube1), float.Parse(_ViewModel.DepthCube1));
    }

    private Cube GetInformationCube2()
    {
        return new(float.Parse(_ViewModel.XPositionCube2), float.Parse(_ViewModel.YPositionCube2), float.Parse(_ViewModel.ZPositionCube2),
                   float.Parse(_ViewModel.WidthCube2), float.Parse(_ViewModel.HeightCube2), float.Parse(_ViewModel.DepthCube2));
    }

    private Cube? LoadInformationCube(string id)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri("https://localhost:44390/");

        Cube? result = null;

        try
        {
            var responseTask = client.GetAsync($"Cube/GetCube/{id}");
            responseTask.Wait();

            HttpResponseMessage response = responseTask.Result;

            if (response.IsSuccessStatusCode)
            {
                var contentTask = response.Content.ReadFromJsonAsync<CubeDTO?>();
                contentTask.Wait();

                CubeDTO? content = contentTask.Result;
                IMapper mapper = _ServiceManager.ServiceProvider.GetRequiredService<IMapper>();

                result = mapper.Map<Cube>(content);
            }
        }
        catch
        {
            
        }

        return result;
    }

    private void OnAboutButtonClick()
    {
        IWPFPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IWPFPresentationManager>();
        presentationManager.LoadPresenter<IAboutPresenter>(true, false);
    }

    private void OnCalculateIntersectionButtonClick()
    {
        Cube cube1 = GetInformationCube1();
        Cube cube2 = GetInformationCube2();

        Cube? cubeIntersection = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);

        if (cubeIntersection is null)
        {
            CleanInformationIntersectionCube();
        }
        else
        {
            _ViewModel.XPositionIntersection = cubeIntersection.X;
            _ViewModel.YPositionIntersection = cubeIntersection.Y;
            _ViewModel.ZPositionIntersection = cubeIntersection.Z;
            _ViewModel.WidthIntersection = cubeIntersection.Width;
            _ViewModel.HeightIntersection = cubeIntersection.Height;
            _ViewModel.DepthIntersection = cubeIntersection.Depth;
        }
    }

    private void OnCleanDataButtonClick()
    {
        _IsCleaning = true;

        CleanInformationCube1();
        CleanInformationCube2();
        CleanInformationIntersectionCube();

        _ViewModel.ExistsIntersection = false;
        _ViewModel.EnableCalculateIntersectionButton = false;

        _IsCleaning = false;
    }

    private bool OnEnableCalculateIntersectionButtonValidating()
    {
        bool canEnable = false;

        if (!_IsCleaning)
        {
            canEnable = !_ViewModel.HasErrors;
            _ViewModel.EnableCalculateIntersectionButton = canEnable;
        }

        return canEnable;
    }

    private bool OnEnableInformationCube1ButtonsValidating()
    {
        bool canEnable = !string.IsNullOrEmpty(_ViewModel.IdCube1);
        _ViewModel.EnableInformationCube1Buttons = canEnable;

        return canEnable;
    }

    private bool OnEnableInformationCube2ButtonsValidating()
    {
        bool canEnable = !string.IsNullOrEmpty(_ViewModel.IdCube2);
        _ViewModel.EnableInformationCube2Buttons = canEnable;

        return canEnable;
    }

    private void OnExistsIntersectionValidating()
    {
        Cube cube1 = GetInformationCube1();
        Cube cube2 = GetInformationCube2();

        bool existIntersection = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        _ViewModel.ExistsIntersection = existIntersection;
    }

    private void OnLoadInformationCube1Click()
    {
        Cube? cube = LoadInformationCube(_ViewModel.IdCube1);

        if (cube is null)
        {
            CleanInformationCube1();
        }
        else
        {
            _ViewModel.XPositionCube1 = Convert.ToString(cube.X);
            _ViewModel.YPositionCube1 = Convert.ToString(cube.Y);
            _ViewModel.ZPositionCube1 = Convert.ToString(cube.Z);
            _ViewModel.WidthCube1 = Convert.ToString(cube.Width);
            _ViewModel.HeightCube1 = Convert.ToString(cube.Height);
            _ViewModel.DepthCube1 = Convert.ToString(cube.Depth);
        }
    }

    private void OnLoadInformationCube2Click()
    {
        Cube? cube = LoadInformationCube(_ViewModel.IdCube2);

        if (cube is null)
        {
            CleanInformationCube2();
        }
        else
        {
            _ViewModel.XPositionCube2 = Convert.ToString(cube.X);
            _ViewModel.YPositionCube2 = Convert.ToString(cube.Y);
            _ViewModel.ZPositionCube2 = Convert.ToString(cube.Z);
            _ViewModel.WidthCube2 = Convert.ToString(cube.Width);
            _ViewModel.HeightCube2 = Convert.ToString(cube.Height);
            _ViewModel.DepthCube2 = Convert.ToString(cube.Depth);
        }
    }

    private void OnSaveInformationCube1Click()
    {

    }

    private void OnSaveInformationCube2Click()
    {

    }

    protected override void OnViewClosed(object? sender, EventArgs e)
    {
        _ViewModel.AboutButtonClick -= OnAboutButtonClick;
        _ViewModel.CalculateIntersectionButtonClick -= OnCalculateIntersectionButtonClick;
        _ViewModel.CleanDataButtonClick -= OnCleanDataButtonClick;
        _ViewModel.EnableCalculateIntersectionButtonValidating -= OnEnableCalculateIntersectionButtonValidating;
        _ViewModel.EnableInformationCube1ButtonsValidating -= OnEnableInformationCube1ButtonsValidating;
        _ViewModel.EnableInformationCube2ButtonsValidating -= OnEnableInformationCube2ButtonsValidating;
        _ViewModel.ExistsIntersectionValidating -= OnExistsIntersectionValidating;
        _ViewModel.LoadInformationCube1Click -= OnLoadInformationCube1Click;
        _ViewModel.LoadInformationCube2Click -= OnLoadInformationCube2Click;
        _ViewModel.SaveInformationCube1Click -= OnSaveInformationCube1Click;
        _ViewModel.SaveInformationCube2Click -= OnSaveInformationCube2Click;

        base.OnViewClosed(sender, e);
    }

    protected override void OnViewModelLinked(object? sender, EventArgs e)
    {
        _ViewModel.Validate();
    }

    private static CubeDTO? SaveInformationCube(string id)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri("https://localhost:44390/");

        CubeDTO? result = null;

        try
        {
            var responseTask = client.GetAsync($"Cube/GetCube/{id}");
            responseTask.Wait();

            HttpResponseMessage response = responseTask.Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadFromJsonAsync<CubeDTO?>().Result;
            }
        }
        catch
        {

        }

        return result;
    }

    #endregion

}
