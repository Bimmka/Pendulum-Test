using System;
using Features.GameStates.States;
using Features.GameStates.States.Interfaces;
using Features.SceneLoading.Scripts;
using Features.Services.StaticData;
using Features.Services.UI.Windows;

namespace Features.GameStates.Factory
{
  public class GameStatesFactory
  {
    private readonly ISceneLoader sceneLoader;
    private readonly IWindowsService windowsService;
    private readonly IStaticDataService staticDataService;

    public GameStatesFactory(ISceneLoader sceneLoader, IWindowsService windowsService, IStaticDataService staticDataService)
    {
      this.sceneLoader = sceneLoader;
      this.windowsService = windowsService;
      this.staticDataService = staticDataService;
    }
    
    public IExitableState Create<TState>(IGameStateMachine gameStateMachine) where TState : IExitableState
    {
      switch (typeof(TState).Name)
      {
        case nameof(GameWinState):
          return new GameWinState(windowsService);
        case nameof(GameLoadState):
          return new GameLoadState(gameStateMachine, sceneLoader);
        case nameof(GameLoopState):
          return new GameLoopState();
        case nameof(MainMenuState):
          return new MainMenuState(sceneLoader, windowsService);
        case nameof(GameLoseState):
          return new GameLoseState(gameStateMachine, staticDataService);
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}