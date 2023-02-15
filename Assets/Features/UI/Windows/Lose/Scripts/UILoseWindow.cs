using System.Collections;
using DG.Tweening;
using Features.GameStates;
using Features.GameStates.States;
using Features.Services.UI.Windows;
using Features.UI.Windows.Base.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.UI.Windows.Lose.Scripts
{
  public class UILoseWindow : BaseWindow
  {
    [SerializeField] private Button leaveButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private float delayOpen = 2f;
    [SerializeField] private float openTime = 1f;
    [SerializeField] private CanvasGroup canvasGroup;
    
    private IGameStateMachine gameStateMachine;
    private IWindowsService windowsService;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine, IWindowsService windowsService)
    {
      this.windowsService = windowsService;
      this.gameStateMachine = gameStateMachine;
    }

    protected override void Subscribe()
    {
      base.Subscribe();
      leaveButton.onClick.AddListener(LoadMainMenu);
      restartButton.onClick.AddListener(RestartGame);
    }

    protected override void Cleanup()
    {
      base.Cleanup();
      leaveButton.onClick.RemoveListener(LoadMainMenu);
      restartButton.onClick.RemoveListener(RestartGame);
    }

    public override void Open()
    {
      base.Open();
      StartCoroutine(WaitOpen());
    }

    private void LoadMainMenu()
    {
      gameStateMachine.Enter<MainMenuState>();
    }

    private void RestartGame()
    {
      windowsService.Close(ID);
    }

    private IEnumerator WaitOpen()
    {
      float time = 0;

      while (time < delayOpen)
      {
        time += Time.deltaTime;
        yield return null;
      }

      canvasGroup.DOFade(1f, openTime).SetEase(Ease.InOutSine);
    }
  }
}