using System.Threading;
using System.Windows.Markup;
using GPM.WPF.View.Localization;

namespace GPM.WPF.View;

public class Localizer
{

    public string? this[string key]
    {
        get
        {
            return CubeIntersectionViewLocale.ResourceManager.GetString(key, Thread.CurrentThread.CurrentCulture);
        }
    }

}
