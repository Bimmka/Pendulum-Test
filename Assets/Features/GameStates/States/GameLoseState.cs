using Features.GameStates.States.Interfaces;
using Features.Services.StaticData;

namespace Features.GameStates.States
{
  public class GameLoseState : IState
  {
    private readonly IGameStateMachine gameStateMachine;
    private readonly IStaticDataService staticDataService;

    public GameLoseState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
    {
      this.gameStateMachine = gameStateMachine;
      this.staticDataService = staticDataService;
    }
    
    public void Enter()
    {
     
    }

    public void Exit()
    {
      
    }
  }
}