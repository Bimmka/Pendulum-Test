using Features.Services.UI.Factory;
using Features.Services.UI.Windows;
using Features.UI.Windows.Base.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.UI.Windows.HUD.Scripts
{
  public class UIHUD : BaseWindow
  {
    [SerializeField] private Button pauseMenuButton;
    
    private IWindowsService windowsService;

    [Inject]
    public void Construct(IWindowsService windowsService)
    {
      this.windowsService = windowsService;
    }

    protected override void Subscribe()
    {
      base.Subscribe();
      pauseMenuButton.onClick.AddListener(OpenPauseMenu);
    }

    protected override void Cleanup()
    {
      base.Cleanup();
      pauseMenuButton.onClick.RemoveListener(OpenPauseMenu);
    }

    private void OpenPauseMenu()
    {
      windowsService.Open(WindowId.PauseMenu);
    }
  }
}