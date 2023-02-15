using Features.Constants;
using Features.Services.UI.Factory;
using Features.Services.UI.Windows;
using Features.UI.Windows.Base.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.UI.Windows.MainMenu.Scripts
{
  public class UIMainMenu : BaseWindow
  {
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    
    private IWindowsService windowsService;

    [Inject]
    public void Construct(IWindowsService windowsService)
    {
      this.windowsService = windowsService;
    }

    protected override void Subscribe()
    {
      base.Subscribe();
      playButton.onClick.AddListener(StartPlay);
      quitButton.onClick.AddListener(Quit);
    }

    protected override void Cleanup()
    {
      base.Cleanup();
      playButton.onClick.RemoveListener(StartPlay);
      quitButton.onClick.RemoveListener(Quit);
    }

    public override void Open()
    {
     
      base.Open();
      
    }

    private void Quit() => 
      Application.Quit();

    private void StartPlay()
    {
      
    }
  }
}