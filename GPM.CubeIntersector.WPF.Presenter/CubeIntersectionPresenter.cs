using GPM.WPF.Model.Json;

namespace GPM.CubeIntersector.WPF.Presenter;

public class CubeIntersectionPresenter : MvpvmPresenter<ICubeIntersectionView, ICubeIntersectionViewModel, IMvpvmServiceManager>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(ICubeIntersectionView view, ICubeIntersectionViewModel viewModel, IMvpvmServiceManager serviceManager) : base(view, viewModel, serviceManager)
    {
        _ViewModel.AboutButtonClick += OnAboutButtonClick;
        _ViewModel.CalculateIntersectionButtonClick += OnCalculateIntersectionButtonClick;
        _ViewModel.CleanDataButtonClick += OnCleanDataButtonClick;
        _ViewModel.EnableCalculateIntersectionButtonValidating += OnEnableCalculateIntersectionButtonValidating;
        _ViewModel.EnableLoadInformationCube1ButtonValidating += OnEnableLoadInformationCube1ButtonValidating;
        _ViewModel.EnableLoadInformationCube2ButtonValidating += OnEnableLoadInformationCube2ButtonValidating;
        _ViewModel.EnableSaveInformationCube1ButtonValidating += OnEnableSaveInformationCube1ButtonValidating;
        _ViewModel.EnableSaveInformationCube2ButtonValidating += OnEnableSaveInformationCube2ButtonValidating;
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

    private void CleanInformation(bool cleanInformationCube1, bool cleanInformationCube2)
    {
        _IsCleaning = true;

        if (cleanInformationCube1 || cleanInformationCube2)
        {
            if (cleanInformationCube1)
            {
                _ViewModel.XPositionCube1 = string.Empty;
                _ViewModel.YPositionCube1 = string.Empty;
                _ViewModel.ZPositionCube1 = string.Empty;

                _ViewModel.WidthCube1 = string.Empty;
                _ViewModel.HeightCube1 = string.Empty;
                _ViewModel.DepthCube1 = string.Empty;

                _ViewModel.EnableSaveInformationCube1Button = false;
            }

            if (cleanInformationCube2)
            {
                _ViewModel.XPositionCube2 = string.Empty;
                _ViewModel.YPositionCube2 = string.Empty;
                _ViewModel.ZPositionCube2 = string.Empty;

                _ViewModel.WidthCube2 = string.Empty;
                _ViewModel.HeightCube2 = string.Empty;
                _ViewModel.DepthCube2 = string.Empty;

                _ViewModel.EnableSaveInformationCube2Button = false;
            }

            _ViewModel.EnableCalculateIntersectionButton = false;
        }

        _ViewModel.XPositionIntersection = null;
        _ViewModel.YPositionIntersection = null;
        _ViewModel.ZPositionIntersection = null;

        _ViewModel.WidthIntersection = null;
        _ViewModel.HeightIntersection = null;
        _ViewModel.DepthIntersection = null;

        _ViewModel.ExistsIntersection = false;
        

        _IsCleaning = false;
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
                //var contentTask = response.Content.ReadFromJsonAsync<CubeDto?>(JsonModelSerializerContext.Default.Options);
                var contentTask = response.Content.ReadFromJsonAsync<CubeDto?>();
                contentTask.Wait();

                IMapper mapper = _ServiceManager.ServiceProvider.GetRequiredService<IMapper>();
                result = mapper.Map<Cube>(contentTask.Result);
            }
        }
        catch
        {
            
        }

        return result;
    }

    private void OnAboutButtonClick()
    {
        IMvpvmPresentationManager presentationManager = _ServiceManager.ServiceProvider.GetRequiredService<IMvpvmPresentationManager>();
        presentationManager.LoadPresenter<IAboutPresenter>(true, false);
    }

    private void OnCalculateIntersectionButtonClick()
    {
        Cube cube1 = GetInformationCube1();
        Cube cube2 = GetInformationCube2();

        Cube? cubeIntersection = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);

        if (cubeIntersection is null)
        {
            CleanInformation(false, false);
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
        CleanInformation(true, true);
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

    private bool OnEnableLoadInformationCube1ButtonValidating()
    {
        bool canEnable = !string.IsNullOrEmpty(_ViewModel.IdCube1);

        _ViewModel.EnableLoadInformationCube1Button = canEnable;

        return canEnable;
    }

    private bool OnEnableLoadInformationCube2ButtonValidating()
    {
        bool canEnable = !string.IsNullOrEmpty(_ViewModel.IdCube2);

        _ViewModel.EnableLoadInformationCube2Button = canEnable;

        return canEnable;
    }

    private bool OnEnableSaveInformationCube1ButtonValidating()
    {
        bool canEnable = false;

        if (!_IsCleaning)
        {
            canEnable = !string.IsNullOrEmpty(_ViewModel.IdCube1);

            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.XPositionCube1)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.YPositionCube1)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.ZPositionCube1)).Any();

            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.WidthCube1)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.HeightCube1)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.DepthCube1)).Any();

            _ViewModel.EnableSaveInformationCube1Button = canEnable;
        }

        return canEnable;
    }

    private bool OnEnableSaveInformationCube2ButtonValidating()
    {
        bool canEnable = false;

        if (_IsCleaning)
        {
            canEnable = !string.IsNullOrEmpty(_ViewModel.IdCube2);

            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.XPositionCube2)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.YPositionCube2)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.ZPositionCube2)).Any();

            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.WidthCube2)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.HeightCube2)).Any();
            canEnable &= !_ViewModel.GetErrors(nameof(_ViewModel.DepthCube2)).Any();

            _ViewModel.EnableSaveInformationCube2Button = canEnable;
        }

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
            CleanInformation(true, false);
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
            CleanInformation(false, true);
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
        Cube cube = GetInformationCube1();
        SaveInformationCube(_ViewModel.IdCube1, cube);
    }

    private void OnSaveInformationCube2Click()
    {
        Cube cube = GetInformationCube2();
        SaveInformationCube(_ViewModel.IdCube2, cube);
    }

    protected override void OnViewClosed(object? sender, EventArgs e)
    {
        _ViewModel.AboutButtonClick -= OnAboutButtonClick;
        _ViewModel.CalculateIntersectionButtonClick -= OnCalculateIntersectionButtonClick;
        _ViewModel.CleanDataButtonClick -= OnCleanDataButtonClick;
        _ViewModel.EnableCalculateIntersectionButtonValidating -= OnEnableCalculateIntersectionButtonValidating;
        _ViewModel.EnableLoadInformationCube1ButtonValidating -= OnEnableLoadInformationCube1ButtonValidating;
        _ViewModel.EnableLoadInformationCube2ButtonValidating -= OnEnableLoadInformationCube2ButtonValidating;
        _ViewModel.EnableSaveInformationCube1ButtonValidating -= OnEnableSaveInformationCube1ButtonValidating;
        _ViewModel.EnableSaveInformationCube2ButtonValidating -= OnEnableSaveInformationCube2ButtonValidating;
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

    private void SaveInformationCube(string id, Cube cube)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri("https://localhost:44390/");

        try
        {
            IMapper mapper = _ServiceManager.ServiceProvider.GetRequiredService<IMapper>();
            CubeDto content = mapper.Map<CubeDto>(cube);

            //var postTask = client.PostAsJsonAsync($"Cube/SetCube/{id}", content, JsonModelSerializerContext.Default.CubeDto.Options);
            var postTask = client.PostAsJsonAsync($"Cube/SetCube/{id}", content);
            postTask.Wait();

            HttpResponseMessage response = postTask.Result;

            if (response.IsSuccessStatusCode)
            {
                // Guardar mensaje de log
            }
        }
        catch
        {

        }
    }

    #endregion

}
