namespace GPM.CubeIntersector.Presenters;

public class CubeIntersectionPresenter : Presenter<ICubeIntersectionView, ICubeIntersectionViewModel>, ICubeIntersectionPresenter
{

    #region constructors / deconstructors / destructors

    public CubeIntersectionPresenter(IServiceProvider services) : base(services)
    {
        Mapper = services.GetRequiredService<IMapper>();
        Configurator = services.GetRequiredService<IConfigurator>();

        ViewModel.AboutButton_Click += OnAboutButton_Click;
        ViewModel.CalculateIntersectionButton_CanExecuteValidating += OnCalculateIntersectionButton_CanExecuteValidating;
        ViewModel.CalculateIntersectionButton_Click += OnCalculateIntersectionButton_Click;
        ViewModel.CleanDataButton_Click += OnCleanDataButton_Click;
        ViewModel.EnglishMenuItem_CanExecuteValidating += OnEnglishMenuItem_CanExecuteValidating;
        ViewModel.EnglishMenuItem_Click += OnEnglishMenuItem_Click;
        ViewModel.LoadInformationCube1Button_CanExecuteValidating += OnLoadInformationCube1Button_CanExecuteValidating;
        ViewModel.LoadInformationCube1Button_Click += OnLoadInformationCube1Button_Click;
        ViewModel.LoadInformationCube2Button_CanExecuteValidating += OnLoadInformationCube2Button_CanExecuteValidating;
        ViewModel.LoadInformationCube2Button_Click += OnLoadInformationCube2Button_Click;
        ViewModel.SaveInformationCube1Button_CanExecuteValidating += OnSaveInformationCube1Button_CanExecuteValidating;
        ViewModel.SaveInformationCube1Button_Click += OnSaveInformationCube1Button_Click;
        ViewModel.SaveInformationCube2Button_CanExecuteValidating += OnSaveInformationCube2Button_CanExecuteValidating;
        ViewModel.SaveInformationCube2Button_Click += OnSaveInformationCube2Button_Click;
        ViewModel.SpanishMenuItem_CanExecuteValidating += OnSpanishMenuItem_CanExecuteValidating;
        ViewModel.SpanishMenuItem_Click += OnSpanishMenuItem_Click;
    }

    #endregion

    #region properties

    private bool IsCleaning { get; set; }

    private IMapper Mapper { get; init; }

    private IConfigurator Configurator { get; init; }

    #endregion

    #region methods

    private void CleanInformation(bool cleanInformationCube1, bool cleanInformationCube2)
    {
        IsCleaning = true;

        if (cleanInformationCube1 || cleanInformationCube2)
        {
            if (cleanInformationCube1)
            {
                ViewModel.XPositionCube1TextBox_Text = string.Empty;
                ViewModel.YPositionCube1TextBox_Text = string.Empty;
                ViewModel.ZPositionCube1TextBox_Text = string.Empty;

                ViewModel.WidthCube1TextBox_Text = string.Empty;
                ViewModel.HeightCube1TextBox_Text = string.Empty;
                ViewModel.DepthCube1TextBox_Text = string.Empty;
            }

            if (cleanInformationCube2)
            {
                ViewModel.XPositionCube2TextBox_Text = string.Empty;
                ViewModel.YPositionCube2TextBox_Text = string.Empty;
                ViewModel.ZPositionCube2TextBox_Text = string.Empty;

                ViewModel.WidthCube2TextBox_Text = string.Empty;
                ViewModel.HeightCube2TextBox_Text = string.Empty;
                ViewModel.DepthCube2TextBox_Text = string.Empty;
            }
        }

        ViewModel.XPositionIntersectionTextBox_Text = null;
        ViewModel.YPositionIntersectionTextBox_Text = null;
        ViewModel.ZPositionIntersectionTextBox_Text = null;

        ViewModel.WidthIntersectionTextBox_Text = null;
        ViewModel.HeightIntersectionTextBox_Text = null;
        ViewModel.DepthIntersectionTextBox_Text = null;

        ViewModel.ExistsIntersectionCheckBox_IsChecked = false;
        
        IsCleaning = false;
    }

    private Cube GetInformationCube1()
    {
        return new(float.Parse(ViewModel.XPositionCube1TextBox_Text), float.Parse(ViewModel.YPositionCube1TextBox_Text), float.Parse(ViewModel.ZPositionCube1TextBox_Text),
                   float.Parse(ViewModel.WidthCube1TextBox_Text), float.Parse(ViewModel.HeightCube1TextBox_Text), float.Parse(ViewModel.DepthCube1TextBox_Text));
    }

    private Cube GetInformationCube2()
    {
        return new(float.Parse(ViewModel.XPositionCube2TextBox_Text), float.Parse(ViewModel.YPositionCube2TextBox_Text), float.Parse(ViewModel.ZPositionCube2TextBox_Text),
                   float.Parse(ViewModel.WidthCube2TextBox_Text), float.Parse(ViewModel.HeightCube2TextBox_Text), float.Parse(ViewModel.DepthCube2TextBox_Text));
    }

    private async Task<Cube?> LoadInformationCube(string id)
    {
        Cube? result = default;

        try
        {
            using HttpClient client = new() { BaseAddress = new Uri("https://localhost:44390/") };
            
            using Task<HttpResponseMessage> responseTask = client.GetAsync($"Cube/GetCube/{id}");
            using HttpResponseMessage response = await responseTask.ConfigureAwait(false);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    using (Task<CubeDto?> contentTask = response.Content.ReadFromJsonAsync(JsonDomainSerializerContext.Default.CubeDto))
                    {
                        result = Mapper.Map<Cube>(await contentTask.ConfigureAwait(false));
                    }

                    break;
                case HttpStatusCode.NoContent:
                    result = null;

                    break;

                case HttpStatusCode.InternalServerError:

                    break;
            }
        }
        catch
        {
            
        }

        return result;
    }

    private void OnAboutButton_Click()
    {
        Presentator.LoadPresenter<IAboutPresenter>(true, false);
    }

    private bool OnCalculateIntersectionButton_CanExecuteValidating()
    {
        bool canExecute = false;

        if (!IsCleaning)
        {
            canExecute = !ViewModel.HasErrors;
        }

        return canExecute;
    }

    private void OnCalculateIntersectionButton_Click()
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
            ViewModel.XPositionIntersectionTextBox_Text = cubeIntersection.X;
            ViewModel.YPositionIntersectionTextBox_Text = cubeIntersection.Y;
            ViewModel.ZPositionIntersectionTextBox_Text = cubeIntersection.Z;
            ViewModel.WidthIntersectionTextBox_Text = cubeIntersection.Width;
            ViewModel.HeightIntersectionTextBox_Text = cubeIntersection.Height;
            ViewModel.DepthIntersectionTextBox_Text = cubeIntersection.Depth;

            ViewModel.ExistsIntersectionCheckBox_IsChecked = true;
        }
    }

    private void OnCleanDataButton_Click()
    {
        CleanInformation(true, true);
    }

    private bool OnEnglishMenuItem_CanExecuteValidating()
    {
        bool canExecute = ViewModel.SelectedLanguage != Language.English;

        return canExecute;
    }

    private void OnEnglishMenuItem_Click()
    {
        ViewModel.SelectedLanguage = Language.English;
        UpdateLanguageMenuItems();

        Configurator.Language = Language.English;
    }

    protected override void OnInitialized(object? sender, EventArgs e)
    {
        ViewModel.Validate();

        ViewModel.SelectedLanguage = Configurator.Language;
        UpdateLanguageMenuItems();
    }

    private bool OnLoadInformationCube1Button_CanExecuteValidating()
    {
        bool canExecute = !string.IsNullOrEmpty(ViewModel.IdCube1TextBox_Text);

        return canExecute;
    }

    private void OnLoadInformationCube1Button_Click()
    {
        using Task<Cube?> loadTask = LoadInformationCube(ViewModel.IdCube1TextBox_Text);
        loadTask.Wait();

        Cube? cube = loadTask.Result;

        if (cube is null)
        {
            CleanInformation(true, false);
        }
        else
        {
            ViewModel.XPositionCube1TextBox_Text = Convert.ToString(cube.X);
            ViewModel.YPositionCube1TextBox_Text = Convert.ToString(cube.Y);
            ViewModel.ZPositionCube1TextBox_Text = Convert.ToString(cube.Z);
            ViewModel.WidthCube1TextBox_Text = Convert.ToString(cube.Width);
            ViewModel.HeightCube1TextBox_Text = Convert.ToString(cube.Height);
            ViewModel.DepthCube1TextBox_Text = Convert.ToString(cube.Depth);
        }
    }

    private bool OnLoadInformationCube2Button_CanExecuteValidating()
    {
        bool canExecute = !string.IsNullOrEmpty(ViewModel.IdCube2TextBox_Text);

        return canExecute;
    }

    private void OnLoadInformationCube2Button_Click()
    {
        using Task<Cube?> loadTask = LoadInformationCube(ViewModel.IdCube2TextBox_Text);
        loadTask.Wait();

        Cube? cube = loadTask.Result;

        if (cube is null)
        {
            CleanInformation(false, true);
        }
        else
        {
            ViewModel.XPositionCube2TextBox_Text = Convert.ToString(cube.X);
            ViewModel.YPositionCube2TextBox_Text = Convert.ToString(cube.Y);
            ViewModel.ZPositionCube2TextBox_Text = Convert.ToString(cube.Z);
            ViewModel.WidthCube2TextBox_Text = Convert.ToString(cube.Width);
            ViewModel.HeightCube2TextBox_Text = Convert.ToString(cube.Height);
            ViewModel.DepthCube2TextBox_Text = Convert.ToString(cube.Depth);
        }
    }

    private bool OnSaveInformationCube1Button_CanExecuteValidating()
    {
        bool canExecute = false;

        if (!IsCleaning)
        {
            canExecute = !string.IsNullOrEmpty(ViewModel.IdCube1TextBox_Text);

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.XPositionCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.YPositionCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.ZPositionCube1TextBox_Text)).Any();

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.WidthCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.HeightCube1TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.DepthCube1TextBox_Text)).Any();
        }

        return canExecute;
    }

    private void OnSaveInformationCube1Button_Click()
    {
        Cube cube = GetInformationCube1();

        using Task<UpsetOperation> saveTask = SaveInformationCube(ViewModel.IdCube1TextBox_Text, cube);
        saveTask.Wait();
    }

    private bool OnSaveInformationCube2Button_CanExecuteValidating()
    {
        bool canExecute = false;

        if (!IsCleaning)
        {
            canExecute = !string.IsNullOrEmpty(ViewModel.IdCube2TextBox_Text);

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.XPositionCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.YPositionCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.ZPositionCube2TextBox_Text)).Any();

            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.WidthCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.HeightCube2TextBox_Text)).Any();
            canExecute &= !ViewModel.GetErrors(nameof(ViewModel.DepthCube2TextBox_Text)).Any();
        }

        return canExecute;
    }

    private void OnSaveInformationCube2Button_Click()
    {
        Cube cube = GetInformationCube2();

        using Task<UpsetOperation> saveTask = SaveInformationCube(ViewModel.IdCube2TextBox_Text, cube);
        saveTask.Wait();
    }

    private bool OnSpanishMenuItem_CanExecuteValidating()
    {
        bool canExecute = ViewModel.SelectedLanguage != Language.Spanish;

        return canExecute;
    }

    private void OnSpanishMenuItem_Click()
    {
        ViewModel.SelectedLanguage = Language.Spanish;
        UpdateLanguageMenuItems();

        Configurator.Language = Language.Spanish;
    }

    protected override void OnView_Closed(object? sender, EventArgs e)
    {
        ViewModel.AboutButton_Click -= OnAboutButton_Click;
        ViewModel.CalculateIntersectionButton_CanExecuteValidating -= OnCalculateIntersectionButton_CanExecuteValidating;
        ViewModel.CalculateIntersectionButton_Click -= OnCalculateIntersectionButton_Click;
        ViewModel.CleanDataButton_Click -= OnCleanDataButton_Click;
        ViewModel.EnglishMenuItem_CanExecuteValidating -= OnEnglishMenuItem_CanExecuteValidating;
        ViewModel.EnglishMenuItem_Click -= OnEnglishMenuItem_Click;
        ViewModel.LoadInformationCube1Button_CanExecuteValidating -= OnLoadInformationCube1Button_CanExecuteValidating;
        ViewModel.LoadInformationCube1Button_Click -= OnLoadInformationCube1Button_Click;
        ViewModel.LoadInformationCube2Button_CanExecuteValidating -= OnLoadInformationCube2Button_CanExecuteValidating;
        ViewModel.LoadInformationCube2Button_Click -= OnLoadInformationCube2Button_Click;
        ViewModel.SaveInformationCube1Button_CanExecuteValidating -= OnSaveInformationCube1Button_CanExecuteValidating;
        ViewModel.SaveInformationCube1Button_Click -= OnSaveInformationCube1Button_Click;
        ViewModel.SaveInformationCube2Button_CanExecuteValidating -= OnSaveInformationCube2Button_CanExecuteValidating;
        ViewModel.SaveInformationCube2Button_Click -= OnSaveInformationCube2Button_Click;
        ViewModel.SpanishMenuItem_CanExecuteValidating -= OnSpanishMenuItem_CanExecuteValidating;
        ViewModel.SpanishMenuItem_Click -= OnSpanishMenuItem_Click;

        base.OnView_Closed(sender, e);
    }

    private async Task<UpsetOperation> SaveInformationCube(string id, Cube cube)
    {
        UpsetOperation result = UpsetOperation.Error;

        try
        {
            using HttpClient client = new() { BaseAddress = new Uri("https://localhost:44390/") };

            CubeDto content = Mapper.Map<CubeDto>(cube);

            using Task<HttpResponseMessage> responseTask = client.PostAsJsonAsync($"Cube/SetCube/{id}", content, JsonDomainSerializerContext.Default.CubeDto);
            using HttpResponseMessage response = await responseTask.ConfigureAwait(false);


            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    using (Task<UpsetOperation> contentTask = response.Content.ReadFromJsonAsync(JsonDomainSerializerContext.Default.UpsetOperation))
                    {
                        result = await contentTask.ConfigureAwait(false);
                    }
                    
                    break;

                case HttpStatusCode.InternalServerError:

                    break;
            }
        }
        catch
        {

        }

        return result;
    }

    private void UpdateLanguageMenuItems()
    {
        ViewModel.SpanishMenuItem_IsChecked = ViewModel.SelectedLanguage == Language.Spanish;
        ViewModel.EnglishMenuItem_IsChecked = ViewModel.SelectedLanguage == Language.English;
    }

    #endregion

}
