using System;

public class UIEventController
{
    public Action<string, string> OnShowPanel;
    public Action OnHidePanel;

    public event Action<string> OnUpdateLifeHUD;
    public event Action<string> OnUpdateScoreHUD;
    public event Action<string> OnUpdateTimeHUD;
}